using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Hotel
{
    public partial class AddRoom : Form
    {
        private string connectionString;

        public AddRoom()
        {
            InitializeComponent();
            this.backButton3.Click += new System.EventHandler(this.backbutton3_Click);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            comboBox1.Items.Add("Свободна");
            comboBox1.Items.Add("Занята");

            
            string databaseFileName = "Database1.mdf";
            string executablePath = Path.GetDirectoryName(Application.ExecutablePath);
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={executablePath}\{databaseFileName};Integrated Security=True";
        }

        private void backbutton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DataRooms dataroomsForm = new DataRooms();
            dataroomsForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int roomId = int.Parse(textBox1.Text);
            int capacity = int.Parse(textBox2.Text);
            string comfort = textBox3.Text;
            decimal price = decimal.Parse(textBox4.Text);
            int occupancyStatus = comboBox1.SelectedItem.ToString() == "Свободна" ? 1 : 0;

            string query = "INSERT INTO Rooms (RoomId, Capacity, Comfort, Price, OccupancyStatus) VALUES (@RoomId, @Capacity, @Comfort, @Price, @OccupancyStatus)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoomId", roomId);
                    command.Parameters.AddWithValue("@Capacity", capacity);
                    command.Parameters.AddWithValue("@Comfort", comfort);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@OccupancyStatus", occupancyStatus);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Номер успешно добавлен в базу данных.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при добавлении номера в базу данных: " + ex.Message);
                    }
                }
            }
        }
    }
}