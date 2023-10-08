using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class Selection : Form
    {
        public int SelectedRoomId { get; set; }
        private DataTable dataTable; 

        public Selection()
        {
            InitializeComponent();
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button2.Click += new System.EventHandler(this.button2_Click);
            comboBox1.Items.Add("ALL");
            Selection_Load(this, EventArgs.Empty);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                SelectedRoomId = Convert.ToInt32(selectedRow.Cells["RoomId"].Value);

                
                MessageBox.Show($"Выбрана комната с ID: {SelectedRoomId}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SelectedRoomId == 0)
            {
                MessageBox.Show("Пожалуйста, выберите комнату.");
                return;
            }

            Order orderForm = new Order();
            orderForm.SelectedRoomId = SelectedRoomId;
            orderForm.Show();
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();  
            Menu menuForm = new Menu();  
            menuForm.Show();  
        }

        private void Selection_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

            
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string databaseFileName = "Database1.mdf";
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={executablePath}{databaseFileName};Integrated Security=True";


            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                
                SqlCommand command = new SqlCommand("SELECT * FROM Rooms", connection);

                
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                
                dataTable = new DataTable();

                
                adapter.Fill(dataTable);

                
                dataGridView1.DataSource = dataTable;
            }

            
            var uniqueComforts = dataTable.AsEnumerable()
                .Select(row => row.Field<string>("Comfort"))
                .Distinct()
                .ToList();

            
            uniqueComforts.Insert(0, "ALL");

            
            comboBox1.DataSource = uniqueComforts;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(textBox8.Text) ||
                string.IsNullOrEmpty(textBox9.Text) ||
                string.IsNullOrEmpty(textBox7.Text) ||
                comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, введите все значения.");
                return;
            }

            
            decimal minPrice = decimal.Parse(textBox8.Text);
            decimal maxPrice = decimal.Parse(textBox9.Text);
            int capacity = int.Parse(textBox7.Text);
            string selectedComfort = comboBox1.SelectedItem.ToString();

            
            DataView dataView = dataTable.DefaultView;

            
            if (selectedComfort != "ALL")
            {
                dataView.RowFilter = $"Price >= {minPrice} AND Price <= {maxPrice} AND Capacity >= {capacity} AND OccupancyStatus = 1 AND Comfort = '{selectedComfort}'";
            }
            else
            {
                dataView.RowFilter = $"Price >= {minPrice} AND Price <= {maxPrice} AND Capacity >= {capacity} AND OccupancyStatus = 1";
            }

            
            dataGridView1.DataSource = dataView;
        }
    }
}