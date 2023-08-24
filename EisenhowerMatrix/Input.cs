using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EisenhowerMain
{
    internal class Input
    {
        public Input() { }

        public string InputTitle()
        {
            string title = Console.ReadLine();
            return title;
        }

        public string InputDeadline()
        {
            string pattern = @"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])$";
            string deadline = Console.ReadLine();
            if (Regex.IsMatch(deadline, pattern))
            {
                return deadline;
            }
            return "dd-MM";

        }

        public string InputImportance()
        {
            string pattern = @"^[YN]$";
            string importance = Console.ReadLine().ToUpper();
            if (Regex.IsMatch(importance, pattern))
            {
                return importance;
            }
            return "Y/N";
        }

        public bool InputConfirmation() 
        {
            ConsoleKeyInfo confirmationKey = Console.ReadKey(intercept: true);

            if (confirmationKey.Key == ConsoleKey.Y)
            {
                Console.Clear();
                Console.WriteLine("Task deleted.");
                Thread.Sleep(1000);
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Deletion cancelled.");
                Thread.Sleep(1000);
                return false;
            }
        }


    }
}
