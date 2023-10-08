using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Hotel
{
    public partial class ChangeRoom : Form
    {
        private string connectionString;

        public ChangeRoom()
        {
            InitializeComponent();
            backButton3.Click += backButton3_Click;
            button1.Click += button1_Click;
            comboBox1.Items.Add("Свободна");
            comboBox1.Items.Add("Занята");

            
            string databaseFileName = "Database1.mdf";
            string executablePath = Path.GetDirectoryName(Application.ExecutablePath);
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={executablePath}\{databaseFileName};Integrated Security=True";
        }

        private void backButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DataRooms dataroomsForm = new DataRooms();
            dataroomsForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int roomId = int.Parse(textBox1.Text);
            int newRoomId = int.Parse(textBox6.Text);
            int newCapacity = int.Parse(textBox3.Text);
            string newComfort = textBox7.Text;
            decimal newPrice = decimal.Parse(textBox5.Text);
            int newOccupancyStatus = comboBox1.SelectedItem.ToString() == "Свободна" ? 1 : 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string updateQuery = "UPDATE dbo.Rooms SET RoomId = @NewRoomId, Capacity = @NewCapacity, Comfort = @NewComfort, Price = @NewPrice, OccupancyStatus = @NewOccupancyStatus WHERE RoomId = @RoomId";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NewRoomId", newRoomId);
                        command.Parameters.AddWithValue("@NewCapacity", newCapacity);
                        command.Parameters.AddWithValue("@NewComfort", newComfort);
                        command.Parameters.AddWithValue("@NewPrice", newPrice);
                        command.Parameters.AddWithValue("@NewOccupancyStatus", newOccupancyStatus);
                        command.Parameters.AddWithValue("@RoomId", roomId);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Room data updated successfully.");
                            
                        }
                        else
                        {
                            MessageBox.Show("Room data update failed.");
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    
                }
            }
        }
    }
}