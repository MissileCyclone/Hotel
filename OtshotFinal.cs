using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hotel
{
    public partial class OtshotFinal : Form
    {
        private DataTable roomsTable;
        private DataTable clientsTable;
        private bool isRoomsTableDisplayed;
        private string connectionString;

        public OtshotFinal()
        {
            InitializeComponent();
            string databaseFileName = "Database1.mdf";
            string executablePath = Path.GetDirectoryName(Application.ExecutablePath);
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={executablePath}\{databaseFileName};Integrated Security=True";
            this.Load += new System.EventHandler(this.OtshotFinal_Load);
            buttonswitch.Click += buttonswitch_Click;
            buttonprint.Click += buttonprint_Click; 
            this.backButton3.Click += new System.EventHandler(this.backbutton3_Click);
        }

        private void backbutton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Otshot otshotForm = new Otshot();
            otshotForm.Show();
        }
        private void OtshotFinal_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            LoadRoomsTable();
        }

        private void LoadRoomsTable()
        {
            string query = "SELECT * FROM Rooms";
            roomsTable = ExecuteQuery(query);
            dataGridView1.DataSource = roomsTable;
            isRoomsTableDisplayed = true;
        }

        private void LoadClientsTable()
        {
            string query = "SELECT * FROM Clients";
            clientsTable = ExecuteQuery(query);
            dataGridView1.DataSource = clientsTable;
            isRoomsTableDisplayed = false;
        }

        private DataTable ExecuteQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable result = new DataTable();
                    result.Load(command.ExecuteReader());
                    return result;
                }
            }
        }

        private void buttonswitch_Click(object sender, EventArgs e)
        {
            if (isRoomsTableDisplayed)
            {
                LoadClientsTable();
            }
            else
            {
                LoadRoomsTable();
            }
        }

        private void buttonprint_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            printDocument.Print();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            StringBuilder report = new StringBuilder();
            report.AppendLine("Топ 3 популярных комнат в таблице Clients (поле RoomId):");
            var topRooms = clientsTable.AsEnumerable()
                .GroupBy(row => row.Field<int>("RoomId"))
                .OrderByDescending(group => group.Count())
                .Take(3)
                .Select(group => group.Key);
            foreach (var roomId in topRooms)
            {
                report.AppendLine($"RoomId: {roomId}");
            }
            report.AppendLine();

            decimal totalDiscount = clientsTable.AsEnumerable()
                .Sum(row => row.Field<decimal>("Discount"));
            decimal totalIncome = clientsTable.AsEnumerable()
                .Sum(row => row.Field<decimal>("Price")) - totalDiscount;
            report.AppendLine($"Сумма скидок: {totalDiscount}");
            report.AppendLine($"Итоговая сумма дохода: {totalIncome}");
            report.AppendLine();

            decimal totalPrice = clientsTable.AsEnumerable()
                .Sum(row => row.Field<decimal>("Price"));
            report.AppendLine($"Итоговая сумма без скидок: {totalPrice}");

            
            Font font = new Font("Arial", 12);
            Brush brush = Brushes.Black;
            float lineHeight = font.GetHeight();

            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            float width = e.MarginBounds.Width;
            float height = e.MarginBounds.Height;

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;

            RectangleF rect = new RectangleF(x, y, width, height);

            e.Graphics.DrawString(report.ToString(), font, brush, rect, format);
        }
    }
}