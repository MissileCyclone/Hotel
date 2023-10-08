using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Hotel
{
    public partial class DeleteUser : Form
    {
        
        private string connectionString;

        public DeleteUser()
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
            DataUsers datausersForm = new DataUsers();
            datausersForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string surname = textBox1.Text;
            string firstName = textBox2.Text;
            string middleName = textBox3.Text;
            string passportData = textBox4.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    
                    string deleteQuery = "DELETE FROM Clients WHERE MiddleName = @MiddleName AND FirstName = @FirstName AND LastName = @LastName AND PassportData = @PassportData";

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        
                        command.Parameters.AddWithValue("@MiddleName", middleName);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", surname);
                        command.Parameters.AddWithValue("@PassportData", passportData);

                        
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User deleted successfully!");
                        }
                        else
                        {
                            MessageBox.Show("User not found!");
                        }
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