using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleExpenseTracker
{
    internal class Expense
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public Expense(string description, decimal amount)
        {
            Description = description;
            Amount = amount;
        }
    }
}
