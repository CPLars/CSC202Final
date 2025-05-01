using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker
{
    //CLass called every time an entry is made
    public class Expense
    {
        //Category of the expense (Ex. Food, Bills, Transport, etc.)
        public string Category { get; set; }

        //Amount of money spent
        public double Amount { get; set; }

        //Date the expense was made
        public DateTime Date { get; set; }

        //Notes or description for the expense
        public string Notes { get; set; }

        //Returns a string representation of the expense entries
        public override string ToString()
        {
            return $"{Date.ToShortDateString()} - {Category}: ${Amount} - {Notes}";
        }
    }
}

