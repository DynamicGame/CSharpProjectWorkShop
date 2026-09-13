using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleExpenseTracker
{
    public class ExpenseTrackerApp
    {
        private List<Expense> _expenses;
        private IUserInteractor _userInteractor;
        public ExpenseTrackerApp(IUserInteractor userInteractor)
        {
            _expenses = new List<Expense>();
            _userInteractor = userInteractor;
        }
        public void Run()
        {
            _userInteractor.DisplayMessage("Welcome to the Expense Tracker!");
            bool exit = false;

            while (!exit)
            {
                _userInteractor.DisplayMessage("Expense Tracker Menu:");
                _userInteractor.DisplayMessage("1. Add Expense");
                _userInteractor.DisplayMessage("2. View Expenses");
                _userInteractor.DisplayMessage("3. View Total Spending");
                _userInteractor.DisplayMessage("4. Delete Expense");
                _userInteractor.DisplayMessage("5. Exit");
                _userInteractor.DisplayMessageOnSameLine("Select an option: ");

                string? input = _userInteractor.GetUserInput();

                switch (input)
                {
                    case "1":
                        AddExpense();
                        break;
                    case "2":
                        ViewExpenses();
                        break;
                    case "3":
                        ViewTotalSpending();
                        break;
                    case "4":
                        DeleteExpense(); 
                        break;
                    case null:
                    case "5":
                        exit = true;
                        break;
                    default:
                        _userInteractor.DisplayMessage("Invalid option. Please try again.");
                        break;
                }
            }


        }

        private void DeleteExpense()
        {
            ViewExpenses();
            if(_expenses.Count == 0)
            {
                return;
            }
            _userInteractor.DisplayMessage("Enter the expense number to delete: ");
            var input = _userInteractor.GetUserInput();
            if (int.TryParse(input, out int index) && index >= 1 && index <= _expenses.Count)
            {
                _expenses.RemoveAt(index - 1);
                _userInteractor.DisplayMessage("Expense deleted successfully.");
            }
            else
            {
                _userInteractor.DisplayMessage("Invalid expense index.");
            }
        }

        void ViewTotalSpending()
        {

            var totalSpending = _expenses.Sum(expense => expense.Amount);
            _userInteractor.DisplayMessage($"Total Spending: {totalSpending:F2}");
        }

        void ViewExpenses()
        {
            int index = 1;
            if (_expenses.Count == 0)
            {
                _userInteractor.DisplayMessage("No expenses recorded.");
                return;
            }
            foreach (var expense in _expenses)
            {
                
                _userInteractor.DisplayMessage(
                    $"{index}. Description: {expense.Description}, Amount: {expense.Amount:F2}");
                index++;
            }


        }

        void AddExpense()
        {
            var description = PromptForDescription();
            var amount = PromptForAmount();
            var expense = new Expense(description, amount);
            _expenses.Add(expense);
        }

        private decimal PromptForAmount()
        {
            decimal amount;
            do
            {
                _userInteractor.DisplayMessage("Enter Expense Amount: ");

                var parseResult = decimal.TryParse(_userInteractor.GetUserInput(), out amount);
                if (!parseResult || amount <= 0)
                {
                    _userInteractor.DisplayMessage(
                        "Invalid amount. Please enter a valid amount greater than zero.");
                }
            } while (amount <= 0);
            return amount;
        }



        private string PromptForDescription()
        {
            string description;
            do
            {
                _userInteractor.DisplayMessage("Enter Expense Description: ");
                description = _userInteractor.GetUserInput()!;
                if (string.IsNullOrWhiteSpace(description))
                {
                    _userInteractor.DisplayMessage(
                        "Invalid description. Please enter a valid description.");
                }
            } while (string.IsNullOrWhiteSpace(description));
            return description.Trim();
        }
    }
}
