using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GroupDocs.Assembly;
using System.IO;

namespace ExpenseTracker
{
    public partial class ExpenseDetails : Form
    {

        public ExpenseTrackerDataContext expenseTracker = new ExpenseTrackerDataContext();

        public ExpenseDetails()
        {
            InitializeComponent();
        }
        private void LoadComboBox()
        {
            try
            {
                var fetchCategories = expenseTracker.ExpenseCategories.Select(r => r.Category);
                //comboBox1.DataSource = fetchCategories;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExpenseDetails_Load(object sender, EventArgs e)
        {
            //LoadComboBox();
            LoadGridView();
        }
        private void UpdateTotalIncome(int finalAmount)
        {
            try
            {
                var updateData = (from currentPrice in expenseTracker.ExpenseIncomings
                                  select currentPrice.Price).FirstOrDefault();
                ExpenseIncoming incoming = expenseTracker.ExpenseIncomings.Single(a => a.Price == updateData);
                incoming.Price = finalAmount;

                expenseTracker.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int GetIncomePrice()
        {
            try
            {
                //var totalPrice = expenseTracker.ExpenseIncomings;
                //var rateSum = totalPrice.Sum(d => d.Price);
                var totalPrice = (from price in expenseTracker.ExpenseIncomings
                                  select price.Price).FirstOrDefault();
                int finalAmount = Convert.ToInt32(totalPrice);

                return finalAmount;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There are no records");
                return 0;
            }
        }
        private int GetExpensePrice()
        {
            try
            {
                var totalPrice = expenseTracker.ExpenseDetails;
                var rateSum = totalPrice.Sum(d => d.Price);
                int finalAmount = Convert.ToInt32(rateSum);

                return finalAmount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public void LoadGridView()
        {
            try
            {
                int incomePrice = GetIncomePrice();
                int expenseTotalPrice = GetExpensePrice();
                var fetchCategories = from data in expenseTracker.ExpenseDetails
                                      select new
                                      {
                                          ID = data.ExpID,
                                          DateTime = data.Date,
                                          //ExpenseType = data.ExpenseCategory,
                                          Details = data.Details,
                                          Price = data.Price,
                                          TotalRemainings = data.RemainingAmount
                                      };

                dataGridView1.DataSource = fetchCategories;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Width = 70;
                dataGridView1.Columns[3].Width = 70;
                dataGridView1.Columns[2].Width = 185;

                var updateData = (from currentPrice in expenseTracker.ExpenseIncomings
                                  select currentPrice.Price).FirstOrDefault();
                label3.Text = updateData.ToString();
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
                int incomePrice = GetIncomePrice();
                if (textBox1.Text != null && richTextBox1.Text != null)
                {
                    //string categoryName = comboBox1.Text;
                    string details = richTextBox1.Text;
                    int price = Convert.ToInt32(textBox1.Text);
                    DateTime currentDate = DateTime.Now.Date;

                    expenseTracker.ExpenseDetails.InsertOnSubmit(new ExpenseDetail()
                        {
                            //ExpenseCategory = categoryName,
                            Details = details,
                            Price = price,
                            RemainingAmount = incomePrice - price,
                            Date = currentDate,
                            CurrentTotalIncome = incomePrice //your total incom against this expense
                        });

                    expenseTracker.SubmitChanges();
                    MessageBox.Show("Expense Detail Added");

                    richTextBox1.Text = "";
                    textBox1.Text = "";

                    int priceToUpdate = incomePrice - price;
                    UpdateTotalIncome(priceToUpdate);

                    LoadGridView();
                    //LoadComboBox();
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
                var data = (from currentPrice in expenseTracker.ExpenseIncomings
                            select currentPrice.Price).ToList();
                if (data.Count == 0)
                {
                    expenseTracker.ExpenseIncomings.InsertOnSubmit(new ExpenseIncoming()
                    {
                        Price = incomingPrice
                    });
                    expenseTracker.SubmitChanges();
                    LoadGridView();
                }
                else
                {

                    var updateData = (from currentPrice in expenseTracker.ExpenseIncomings
                                                  select currentPrice.Price).FirstOrDefault();
                    ExpenseIncoming incoming = expenseTracker.ExpenseIncomings.Single(a => a.Price == updateData);
                    incoming.Price = updateData + incomingPrice;
                    expenseTracker.SubmitChanges();
                    LoadGridView();
                }
                textBox2.Text = "";
                MessageBox.Show("Incoming Price Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There are no records");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Setting up source word template 
            FileStream template = File.OpenRead("../../../../Data/Samples/Source/Expense Sheet.docx");
            //Setting up destination word report 
            FileStream output = File.Create("../../../../Data/Samples/Destination/Expense Sheet Report.docx");

            //Generate the report
            DocumentAssembler doc = new DocumentAssembler();
            //Beside data source and output path it takes dataSourceObject and dataSourceString
            doc.AssembleDocument(template, output, GenerateReport(), "ExpenseDetails");
        }

        public static IEnumerable<ExpenseDetail> GenerateReport()
        {
            ExpenseTrackerDataContext expenseTracker = new ExpenseTrackerDataContext();
            return expenseTracker.ExpenseDetails;
        }
    }

}
