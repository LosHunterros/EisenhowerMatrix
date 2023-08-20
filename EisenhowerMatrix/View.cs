using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMain
{
    internal class View
    {
        public View() { }
        public void MainScrean(TodoMatrix matrix)
        {
            Console.WriteLine(matrix);
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add New Item");
            Console.WriteLine("2. Mark/Unmark Task");
            Console.WriteLine("3. Archive");
            Console.WriteLine("4. Delete task");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.Write("Chose option: ");
        }

        public void AddTaskView(string title, string deadline, string importance)
        {
            Console.Clear();
            Console.WriteLine("New Task");
            Console.WriteLine();
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Deadline: {deadline}");
            Console.WriteLine($"Important: {importance}");
        }
    }
}
