using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BudgetTracker;

namespace BudgetTracker
{
    public partial class Form1 : Form
    {
        //List that holds expense entries in memory
        private List<Expense> expenses = new List<Expense>();

        //Predefined list of categories for the dropdown
        private string[] categories = { "Food", "Bills", "Entertainment", "Transport", "Other" };

        public Form1()
        {
            InitializeComponent();

            //Add predefined values to Category
            Category.Items.AddRange(categories);
            Category.SelectedIndex = 0; //Sets the default selection
        }

        //Event handler for the "Add Expense" button
        private void addExpense_Click(object sender, EventArgs e)
        {
            try
            {
                //Read input values from form values
                string category = Category.SelectedItem.ToString();
                double amount = double.Parse(Amount.Text);
                DateTime date = datePicker.Value;
                string notes = Notes.Text;

                //Check for negative or zero amount
                if (amount <= 0)
                {
                    MessageBox.Show("Amount must be greater than 0.");
                    return;
                }

                //Create a new expense object
                Expense exp = new Expense
                {
                    Category = category,
                    Amount = amount,
                    Date = date,
                    Notes = notes
                };

                //Add the expense to the list
                expenses.Add(exp);

                //Notify user and clear fields
                MessageBox.Show("Expense added!");
                ClearForm();
            }
            catch (FormatException)
            {
                //Handle non-numerical inputs in the amount field
                MessageBox.Show("Please enter a valid number for amount.");
            }
        }

        //Clears all fields on the form
        private void ClearForm()
        {
            Amount.Clear();
            Notes.Clear();
            Category.SelectedIndex = 0;
            datePicker.Value = DateTime.Now;
        }

        //Event handler for the "Save" button
        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "expenses.txt";

                //If the file exists, ask user before overwriting
                if (File.Exists(filePath))
                {
                    var result = MessageBox.Show("File exists. Overwrite?", "Confirm", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        return;
                }

                //Write each expense to the file in comma-separated format
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var exp in expenses)
                    {
                        writer.WriteLine($"{exp.Date},{exp.Category},{exp.Amount},{exp.Notes}");
                    }
                }
                MessageBox.Show("Expenses saved to file.");
            }
            catch (Exception ex)
            {
                //Handle for any errors during saving
                MessageBox.Show("Error saving file: " + ex.Message);
            }
        }

        //Event handler for the "Load" button
        private void Load_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "expenses.txt";

                //Check if the file exists before loading
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("No file found.");
                    return;
                }

                //Clear current list
                expenses.Clear();

                //Read each line and turn into an Expense object
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    string[] parts = line.Split(',');
                    Expense exp = new Expense
                    {
                        Date = DateTime.Parse(parts[0]),
                        Category = parts[1],
                        Amount = double.Parse(parts[2]),
                        Notes = parts[3]
                    };
                    expenses.Add(exp);
                }

                MessageBox.Show("Expenses loaded.");
            }
            catch (Exception ex)
            {
                //Handle any file read or format issues
                MessageBox.Show("Error reading file: " + ex.Message);
            }
        }

        //Event handler for the "View Summary" button
        private void viewSummary_Click(object sender, EventArgs e)
        {
            //Open Form2 and pass the list of expenses to it
            Form2 summaryForm = new Form2(expenses);
            summaryForm.ShowDialog();
        }
    }
}

