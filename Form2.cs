using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetTracker
{
    public partial class Form2 : Form
    {
        //Holds the list of expenses entered from Form1
        private List<Expense> expenses;

        //Receives the list of expenses and initializes the form
        public Form2(List<Expense> expenseList)
        {
            InitializeComponent();
            expenses = expenseList;  //Store the list
            DisplayExpenses();       //Show expenses in list format
            DisplayTotal();          //Show the total amount
        }

        //Fills summary list with each expense
        private void DisplayExpenses()
        {
            Summary.Items.Clear(); //Clear any previous items

            //Loop through each expense and add it to the Summary list
            foreach (var exp in expenses)
            {
                Summary.Items.Add(exp.ToString());
            }
        }

        //Calculates and displays the total amount spent
        private void DisplayTotal()
        {
            //Add all expenses into a total
            double total = expenses.Sum(e => e.Amount);

            //Display the Total label with sum
            Total.Text = $"Total Spent: ${total:F2}";
        }
    }
}
