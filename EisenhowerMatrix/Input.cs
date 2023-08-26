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
            return Console.ReadLine();
        }

        public string InputDeadline()
        {
            string pattern = @"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])$";
            string deadline = Console.ReadLine();
            return Regex.IsMatch(deadline, pattern) ? deadline : "dd-MM";
        }

        public string InputImportance()
        {
            string pattern = @"^[YN]$";
            string importance = Console.ReadLine().ToUpper();
            return Regex.IsMatch(importance, pattern) ? importance : "Y/N";
        }

        public bool InputConfirmation() 
        {
            ConsoleKeyInfo confirmationKey = Console.ReadKey(intercept: true);
            bool confirmation = confirmationKey.Key == ConsoleKey.Y;
            Console.Clear();
            Console.WriteLine(confirmation ? "Task deleted." : "Deletion cancelled.");
            Thread.Sleep(1000);         
            return confirmation;
        }


    }
}
