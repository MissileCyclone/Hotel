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
    public partial class DataRooms : Form
    {
        public DataRooms()
        {
            InitializeComponent();
            this.backButton4.Click += new System.EventHandler(this.backButton4_Click);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button3.Click += new System.EventHandler(this.button3_Click);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRoom addroomForm = new AddRoom();
            addroomForm.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ChangeRoom changeroomForm = new ChangeRoom();
            changeroomForm.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DeleteRoom deleteroomForm = new DeleteRoom();
            deleteroomForm.Show();
            this.Hide();
        }
        private void backButton4_Click(object sender, EventArgs e)
        {
            this.Hide();  
            Menu menuForm = new Menu();  
            menuForm.Show();  
        }
    }
}
