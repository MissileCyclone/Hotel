using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Hotel
{
    public partial class Order : Form
    {
        private string connectionString;

        public int SelectedRoomId { get; set; }

        public Order()
        {
            InitializeComponent();
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            this.button1.Click += new System.EventHandler(this.button1_Click);

            
            string databaseFileName = "Database1.mdf";
            string executablePath = Path.GetDirectoryName(Application.ExecutablePath);
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={executablePath}\{databaseFileName};Integrated Security=True";
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Selection selectionForm = new Selection();
            selectionForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lastName = textBox1.Text;
            string firstName = textBox2.Text;
            string middleName = textBox3.Text;
            string passportData = textBox4.Text;
            string comment = textBox10.Text;
            string dateFormat = "dd.MM.yyyy";
            DateTime checkInDate;

            if (!DateTime.TryParseExact(textBox5.Text, dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out checkInDate))
            {
                MessageBox.Show("Invalid check-in date format.");
                return;
            }

            int durationDays;

            if (!int.TryParse(textBox6.Text, out durationDays))
            {
                MessageBox.Show("Invalid rental duration format. Please enter a valid number of days.");
                return;
            }

            DateTime checkOutDate = checkInDate.AddDays(durationDays);

            int clientId = 0;
            decimal roomPrice = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    
                    string getNextClientIdQuery = "SELECT COALESCE((SELECT MAX(ClientId) + 1 FROM Clients), 1) AS NextClientId;";
                    using (SqlCommand getNextClientIdCommand = new SqlCommand(getNextClientIdQuery, connection))
                    {
                        clientId = Convert.ToInt32(getNextClientIdCommand.ExecuteScalar());
                    }

                    
                    string getRoomPriceQuery = "SELECT Price FROM Rooms WHERE RoomId = @RoomId;";
                    using (SqlCommand getRoomPriceCommand = new SqlCommand(getRoomPriceQuery, connection))
                    {
                        getRoomPriceCommand.Parameters.AddWithValue("@RoomId", SelectedRoomId);
                        roomPrice = Convert.ToDecimal(getRoomPriceCommand.ExecuteScalar());
                    }

                    
                    string checkPassportDataQuery = "SELECT COUNT(*) FROM Clients WHERE PassportData = @PassportData;";
                    using (SqlCommand checkPassportDataCommand = new SqlCommand(checkPassportDataQuery, connection))
                    {
                        checkPassportDataCommand.Parameters.AddWithValue("@PassportData", passportData);
                        int repeatCount = Convert.ToInt32(checkPassportDataCommand.ExecuteScalar());

                        decimal discount = 0;
                        if (repeatCount >= 3 && repeatCount < 15)
                        {
                            discount = 0.05m;
                        }
                        else if (repeatCount >= 15 && repeatCount < 20)
                        {
                            discount = 0.1m;
                        }
                        else if (repeatCount >= 20)
                        {
                            discount = 0.2m;
                        }

                        decimal discountAmount = roomPrice * discount;
                        decimal totalPrice = roomPrice - discountAmount;

                        
                        string insertClientQuery = "INSERT INTO Clients (ClientId, LastName, FirstName, MiddleName, PassportData, Comment, CheckInDate, CheckOutDate, RoomId, Price, Discount) " +
                                                   "VALUES (@ClientId, @LastName, @FirstName, @MiddleName, @PassportData, @Comment, @CheckInDate, @CheckOutDate, @RoomId, @Price, @Discount);";
                        using (SqlCommand insertClientCommand = new SqlCommand(insertClientQuery, connection))
                        {
                            insertClientCommand.Parameters.AddWithValue("@ClientId", clientId);
                            insertClientCommand.Parameters.AddWithValue("@LastName", lastName);
                            insertClientCommand.Parameters.AddWithValue("@FirstName", firstName);
                            insertClientCommand.Parameters.AddWithValue("@MiddleName", middleName);
                            insertClientCommand.Parameters.AddWithValue("@PassportData", passportData);
                            insertClientCommand.Parameters.AddWithValue("@Comment", comment);
                            insertClientCommand.Parameters.AddWithValue("@CheckInDate", checkInDate);
                            insertClientCommand.Parameters.AddWithValue("@CheckOutDate", checkOutDate);
                            insertClientCommand.Parameters.AddWithValue("@RoomId", SelectedRoomId);
                            insertClientCommand.Parameters.AddWithValue("@Price", roomPrice);
                            insertClientCommand.Parameters.AddWithValue("@Discount", discountAmount);

                            insertClientCommand.ExecuteNonQuery();
                        }

                        
                        string roomQuery = "UPDATE Rooms SET OccupancyStatus = 0 WHERE RoomId = @RoomId;";
                        using (SqlCommand roomCommand = new SqlCommand(roomQuery, connection))
                        {
                            roomCommand.Parameters.AddWithValue("@RoomId", SelectedRoomId);
                            roomCommand.ExecuteNonQuery();
                        }

                        MessageBox.Show($"User registered successfully. Client ID: {clientId}\n\nRoom Price: {roomPrice}\nDiscount: {discountAmount}\nTotal Price: {totalPrice}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error registering user: " + ex.Message);
            }
        }
    }
}