using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Hotel
{
    public partial class AddUser : Form
    {
        private string connectionString;

        public AddUser()
        {
            InitializeComponent();
            this.backButton3.Click += new System.EventHandler(this.backbutton3_Click);
            this.button1.Click += new System.EventHandler(this.button1_Click);

            
            string databaseFileName = "Database1.mdf";
            string executablePath = Path.GetDirectoryName(Application.ExecutablePath);
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={executablePath}\{databaseFileName};Integrated Security=True";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    
                    string checkQuery = "SELECT COUNT(*) FROM Clients WHERE LastName = @LastName AND FirstName = @FirstName AND MiddleName = @MiddleName AND PassportData = @PassportData";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@LastName", textBox1.Text);
                    checkCommand.Parameters.AddWithValue("@FirstName", textBox2.Text);
                    checkCommand.Parameters.AddWithValue("@MiddleName", textBox3.Text);
                    checkCommand.Parameters.AddWithValue("@PassportData", textBox4.Text);

                    int existingUserCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (existingUserCount > 0)
                    {
                        MessageBox.Show("User already exists!");
                        return;
                    }

                    
                    int clientId = GetNextClientId(connection);

                    string insertQuery = "INSERT INTO Clients (ClientId, LastName, FirstName, MiddleName, PassportData, Comment) VALUES (@ClientId, @LastName, @FirstName, @MiddleName, @PassportData, @Comment)";

                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@ClientId", clientId);
                    command.Parameters.AddWithValue("@LastName", textBox1.Text);
                    command.Parameters.AddWithValue("@FirstName", textBox2.Text);
                    command.Parameters.AddWithValue("@MiddleName", textBox3.Text);
                    command.Parameters.AddWithValue("@PassportData", textBox4.Text);
                    command.Parameters.AddWithValue("@Comment", textBox5.Text);

                    command.ExecuteNonQuery();

                    MessageBox.Show("User added successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message);
            }
        }

        private int GetNextClientId(SqlConnection connection)
        {
            string query = "SELECT ISNULL(MAX(ClientId), 0) + 1 FROM Clients";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private void backbutton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DataUsers datausersForm = new DataUsers();
            datausersForm.Show();
        }
    }
}