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
    partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            this.оПрограммеToolStripMenuItem1.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem1_Click);
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            Selection selectionForm = new Selection();
            selectionForm.Show();
            this.Hide();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            Return returnForm = new Return();
            returnForm.Show();
            this.Hide();
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            DataUsers dataUsersForm = new DataUsers();
            dataUsersForm.Show();
            this.Hide();
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            DataRooms dataRoomsForm = new DataRooms();
            dataRoomsForm.Show();
            this.Hide();
        }

        
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Otshot otshotForm = new Otshot();
            otshotForm.Show();
            this.Hide();
        }

        
        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
            this.Hide();
        }

        
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}