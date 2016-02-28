using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTracker
{
    public partial class DisplayExpenses : Form
    {
        public DisplayExpenses()
        {
            InitializeComponent();
        }

        private ExpenseTrackerDataContext expenseTracker = new ExpenseTrackerDataContext();
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        private void LoadData()
        {
            try
            {
                var fetchCategories = from data in expenseTracker.ExpenseDetails
                                      select new
                                      {

                                          Date_Time = data.Date,
                                          Expense_Category = data.ExpenseCategory,
                                          Expense_Details = data.Details,
                                          Expense_Price = data.Price
                                      };

                dataGridView1.DataSource = fetchCategories;
                dataGridView1.Columns[2].Width = 920;


                var fetchExpenseCategories = (from data in expenseTracker.ExpenseCategories
                                              select new
                                              {
                                                  Category = data.Category
                                              }).ToList();

                comboBox1.DataSource = fetchExpenseCategories;
                comboBox1.DisplayMember = "Category";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DisplayExpenses_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);

            //PaintEventArgs myPaintArgs = new PaintEventArgs(e.Graphics, new Rectangle(new Point(0, 0), this.Size));
            //this.InvokePaint(dataGridView1, myPaintArgs);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dateTimePicker1.Value;
                DateTime toDate = dateTimePicker2.Value;

                var fetchCategories = from data in expenseTracker.ExpenseDetails
                                      where data.Date >= fromDate.Date && data.Date <= toDate
                                      select new
                                      {

                                          Date_Time = data.Date,
                                          Expense_Category = data.ExpenseCategory,
                                          Expense_Details = data.Details,
                                          Expense_Price = data.Price
                                      };

                dataGridView1.DataSource = fetchCategories;
                dataGridView1.Columns[2].Width = 920;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string selectedCategory = comboBox1.Text;
                var filteredResults = from data in expenseTracker.ExpenseDetails
                                      where data.ExpenseCategory == selectedCategory
                                      select new
                                      {

                                          Date_Time = data.Date,
                                          Expense_Category = data.ExpenseCategory,
                                          Expense_Details = data.Details,
                                          Expense_Price = data.Price
                                      };

                dataGridView1.DataSource = filteredResults;
                dataGridView1.Columns[2].Width = 920;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
