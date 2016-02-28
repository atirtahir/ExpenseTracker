using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ExpenseTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Process.Start("http://ainigmadev.com/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CategoryDetails details = new CategoryDetails();
            details.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExpenseDetails expDetails = new ExpenseDetails();
            expDetails.Show();
        }
    }
}
