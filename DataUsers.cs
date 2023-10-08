using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class DataUsers : Form
    {
        public DataUsers()
        {
            InitializeComponent();
            this.backButton3.Click += new System.EventHandler(this.backButton3_Click);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button3.Click += new System.EventHandler(this.button3_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUser adduserForm = new AddUser();
            adduserForm.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ChangeUser changeuserForm = new ChangeUser();
            changeuserForm.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DeleteUser deleteuserForm = new DeleteUser();
            deleteuserForm.Show();
            this.Hide();
        }

        private void backButton3_Click(object sender, EventArgs e)
        {
            this.Hide();  
            Menu menuForm = new Menu();  
            menuForm.Show();  
        }
    }
}
