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
    public partial class Otshot : Form
    {
        public Otshot()
        {
            InitializeComponent();
            this.backButton3.Click += new System.EventHandler(this.backbutton3_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
                OtshotFinal otshotfinalForm = new OtshotFinal();
                otshotfinalForm.Show();
                this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportGraph reportgraphForm = new ReportGraph();
                reportgraphForm.Show();
                this.Hide();
        }
        private void backbutton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menuForm = new Menu();
            menuForm.Show();
        }
    }
}
