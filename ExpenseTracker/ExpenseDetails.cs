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
    public partial class ExpenseDetails : Form
    {

        private ExpenseTrackerDataContext expenseTracker = new ExpenseTrackerDataContext();

        public ExpenseDetails()
        {
            InitializeComponent();
        }
        private void LoadComboBox()
        {
            try
            {
                var fetchCategories = expenseTracker.ExpenseCategories.Select(r => r.Category);
                comboBox1.DataSource = fetchCategories;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExpenseDetails_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadGridView();
        }

        public void LoadGridView()
        {
            try
            {
                var fetchCategories = from data in expenseTracker.ExpenseDetails
                                      select new
                                      {
                                          ID = data.ExpID,
                                          DateTime = data.Date,
                                          ExpenseType = data.ExpenseCategory,
                                          Details = data.Details,
                                          Price = data.Price
                                      };

                dataGridView1.DataSource = fetchCategories;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Width = 70;
                dataGridView1.Columns[3].Width = 200;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != null && richTextBox1.Text != null)
                {
                    string categoryName = comboBox1.Text;
                    string details = richTextBox1.Text;
                    int price = Convert.ToInt32(textBox1.Text);
                    DateTime currentDate = DateTime.Now.Date;

                    expenseTracker.ExpenseDetails.InsertOnSubmit(new ExpenseDetail()
                        {
                            ExpenseCategory = categoryName,
                            Details = details,
                            Price = price,
                            Date = currentDate
                        });
                    expenseTracker.SubmitChanges();
                    MessageBox.Show("Expense Detail Added");

                    richTextBox1.Text = "";
                    textBox1.Text = "";

                    LoadGridView();
                    LoadComboBox();
                }
                else
                {
                    MessageBox.Show("Please Provide Expense Details and Price");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisplayExpenses display = new DisplayExpenses();
            display.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        long selectedIDs = Convert.ToInt64(dataGridView1.SelectedRows[i].Cells[0].Value);
                        ExpenseDetail deleteRecords = expenseTracker.ExpenseDetails.First(d => d.ExpID == selectedIDs);
                        expenseTracker.ExpenseDetails.DeleteOnSubmit(deleteRecords);

                        expenseTracker.SubmitChanges();
                    }

                    MessageBox.Show("Expense Category Deleted");
                    LoadGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int incomingPrice = Convert.ToInt32(textBox2.Text);
                expenseTracker.ExpenseIncomings.InsertOnSubmit(new ExpenseIncoming()
                    {
                        Price = incomingPrice
                    });
                expenseTracker.SubmitChanges();
                textBox2.Text = "";
                MessageBox.Show("Incoming Price Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
        }
    }
}
