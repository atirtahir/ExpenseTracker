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
    public partial class CategoryDetails : Form
    {
        public CategoryDetails()
        {
            InitializeComponent();
        }

        private ExpenseTrackerDataContext expenseTracker = new ExpenseTrackerDataContext();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != null)
                {
                    string categoryName = textBox1.Text;
                    expenseTracker.ExpenseCategories.InsertOnSubmit(new ExpenseCategory()
                    {
                        Category = categoryName
                    });
                    expenseTracker.SubmitChanges();
                    MessageBox.Show("Expense Category Added");

                    textBox1.Text = "";

                    LoadCategories();
                }
                else
                {
                    MessageBox.Show("Please Provide a Category");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CategoryDetails_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                var fetchCategories = from data in expenseTracker.ExpenseCategories
                                      select new 
                                      {
                                          CatID = data.CatID,
                                          Category = data.Category
                                      };

                dataGridView1.DataSource = fetchCategories;
                dataGridView1.Columns[1].Width = 350;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        long selectedIDs = Convert.ToInt64(dataGridView1.SelectedRows[i].Cells[0].Value);
                        ExpenseCategory deleteRecords = expenseTracker.ExpenseCategories.First(d => d.CatID == selectedIDs);
                        expenseTracker.ExpenseCategories.DeleteOnSubmit(deleteRecords);

                        expenseTracker.SubmitChanges();
                    }

                    MessageBox.Show("Expense Category Deleted");
                    LoadCategories();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
        }
    }
}
