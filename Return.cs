using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Hotel
{
    public partial class Return : Form
    {
        private string connectionString;
        private DataTable dataTable;

        public Return()
        {
            InitializeComponent();
            this.backButton1.Click += new System.EventHandler(this.backButton1_Click);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);

            
            string databaseFileName = "Database1.mdf";
            string executablePath = Path.GetDirectoryName(Application.ExecutablePath);
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={executablePath}\{databaseFileName};Integrated Security=True";

            
            LoadData();
        }

        private void LoadData()
        {
            
            DateTime currentDate = DateTime.Now.Date;

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                connection.Open();

                
                string query = "SELECT * FROM Rooms WHERE RoomId IN (SELECT RoomId FROM Clients WHERE CheckOutDate <= @CurrentDate)";

                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    command.Parameters.AddWithValue("@CurrentDate", currentDate);

                    
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        
                        dataTable = new DataTable("RoomsData");

                        
                        adapter.Fill(dataTable);

                        
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                int roomId = (int)dataGridView1.SelectedRows[0].Cells["RoomId"].Value;

                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    
                    connection.Open();

                    
                    string query = "UPDATE Rooms SET OccupancyStatus = 1 WHERE RoomId = @RoomId";

                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@RoomId", roomId);

                        
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void backButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menuForm = new Menu();
            menuForm.Show();
        }
    }
}