using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Hotel
{
    public partial class ReportGraph : Form
    {
        private string ConnectionString;

        public ReportGraph()
        {
            InitializeComponent();
            ConnectionString = GetConnectionString();

            
            InitializeChartElements();
            this.backButton3.Click += new System.EventHandler(this.backbutton3_Click);
        }

        private void backbutton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Otshot otshotForm = new Otshot();
            otshotForm.Show();
        }
        private string GetConnectionString()
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string databaseFileName = "Database1.mdf";
            return $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={executablePath}{databaseFileName};Integrated Security=True";
        }

        private void InitializeChartElements()
        {
            
            chartBookings.Series.Clear();
            Series bookingsSeries = new Series("Bookings");
            bookingsSeries.ChartType = SeriesChartType.Column; 
            chartBookings.Series.Add(bookingsSeries);

            
            chartRevenue.Series.Clear();
            Series revenueSeries = new Series("Revenue");
            revenueSeries.ChartType = SeriesChartType.Column; 
            chartRevenue.Series.Add(revenueSeries);
        }

        private void ReportGraph_Load(object sender, EventArgs e)
        {
            LoadBookingsByMonth();
            LoadRevenueByMonth();
        }

        private void LoadBookingsByMonth()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT MONTH(CheckInDate) AS Month, COUNT(*) AS Bookings FROM Clients GROUP BY MONTH(CheckInDate)";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int month = Convert.ToInt32(reader["Month"]);
                    int bookings = Convert.ToInt32(reader["Bookings"]);

                    chartBookings.Series["Bookings"].Points.AddXY(month, bookings);
                }

                reader.Close();
            }
        }

        private void LoadRevenueByMonth()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT MONTH(CheckInDate) AS Month, SUM(Price) AS Revenue FROM Clients GROUP BY MONTH(CheckInDate)";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int month = Convert.ToInt32(reader["Month"]);
                    double revenue = Convert.ToDouble(reader["Revenue"]);

                    chartRevenue.Series["Revenue"].Points.AddXY(month, revenue);
                }

                reader.Close();
            }
        }
    }
}