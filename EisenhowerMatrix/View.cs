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
        public void MainScreen(TodoMatrix matrix)
        {
            Console.Clear();
            Console.WriteLine(matrix);
            Console.WriteLine();
            Console.WriteLine("Use [UP/DOWN] arrow keys to navigate tasks.");
            Console.WriteLine("Press [TAB] to change quarters");
            Console.WriteLine("Press [ENTER] to mark / unmark task.");
            Console.WriteLine("Press [A] to add task.");
            Console.WriteLine("Press [D] to delete task.");
            Console.WriteLine("Press [S] to archive done tasks.");
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

       public void RemoveIfSure(string title)
        {
            Input input = new Input();
            Console.Clear();
            Console.WriteLine($"Are you sure about removing task: {title}? Y/N");
        }
    }
}
