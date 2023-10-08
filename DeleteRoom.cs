using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Hotel
{
    public partial class DeleteRoom : Form
    {
        
        private string connectionString;

        public DeleteRoom()
        {
            InitializeComponent();
            this.backButton3.Click += new System.EventHandler(this.backbutton3_Click);
            this.button1.Click += new System.EventHandler(this.button1_Click);

            
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
            int roomId;

            if (int.TryParse(textBox1.Text, out roomId))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string deleteQuery = "DELETE FROM Rooms WHERE RoomId = @RoomId";

                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@RoomId", roomId);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Room deleted successfully.");
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete room. Room ID not found.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid room ID. Please enter a valid numeric ID.");
            }
        }
    }
}