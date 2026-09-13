using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleExpenseTracker
{
    internal class ConsoleInteractor : IUserInteractor
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayMessageOnSameLine(string message)
        {
            Console.Write(message);
        }

        public string? GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}
