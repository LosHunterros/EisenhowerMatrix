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
            Console.WriteLine(matrix.ToString());
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("1. Add New Item");
            Console.WriteLine("2. Mark/Unmark Task");
            Console.WriteLine("3. Archive");
            Console.WriteLine("4. Exit");
            Console.WriteLine();
            Console.Write("Chose option: ");
        }
    }
}
