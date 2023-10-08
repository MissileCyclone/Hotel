using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Hotel
{
    public partial class ChangeUser : Form
    {
        
        private string connectionString;

        public ChangeUser()
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
            string lastNameInitial = textBox1.Text;
            string firstNameInitial = textBox2.Text;
            string middleNameInitial = textBox3.Text;
            string passportDataInitial = textBox4.Text;

            string lastNameChanged = textBox8.Text;
            string firstNameChanged = textBox5.Text;
            string middleNameChanged = textBox7.Text;
            string passportDataChanged = textBox6.Text;
            string comment = textBox9.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    
                    string query = "UPDATE Clients SET LastName = @LastNameChanged, FirstName = @FirstNameChanged, MiddleName = @MiddleNameChanged, PassportData = @PassportDataChanged, Comment = @Comment WHERE (LastName = @LastNameInitial OR @LastNameInitial IS NULL) AND (FirstName = @FirstNameInitial OR @FirstNameInitial IS NULL) AND (MiddleName = @MiddleNameInitial OR @MiddleNameInitial IS NULL) AND (PassportData = @PassportDataInitial OR @PassportDataInitial IS NULL)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@LastNameChanged", lastNameChanged);
                        command.Parameters.AddWithValue("@FirstNameChanged", firstNameChanged);
                        command.Parameters.AddWithValue("@MiddleNameChanged", middleNameChanged);
                        command.Parameters.AddWithValue("@PassportDataChanged", passportDataChanged);
                        command.Parameters.AddWithValue("@Comment", comment);
                        command.Parameters.AddWithValue("@LastNameInitial", string.IsNullOrEmpty(lastNameInitial) ? (object)DBNull.Value : lastNameInitial);
                        command.Parameters.AddWithValue("@FirstNameInitial", string.IsNullOrEmpty(firstNameInitial) ? (object)DBNull.Value : firstNameInitial);
                        command.Parameters.AddWithValue("@MiddleNameInitial", string.IsNullOrEmpty(middleNameInitial) ? (object)DBNull.Value : middleNameInitial);
                        command.Parameters.AddWithValue("@PassportDataInitial", string.IsNullOrEmpty(passportDataInitial) ? (object)DBNull.Value : passportDataInitial);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No data found matching the initial values.");
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