using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMain
{
    internal class EisenhowerMain
    {
        static void Main(String[] args)
        {
            TodoMatrix todoMatrix = new TodoMatrix();

            bool run = true;
            var menager = new DataManager();
            menager.DisplayTasks(todoMatrix);
            UserInteraction interaction = new UserInteraction(todoMatrix);
            while (run)
            {
                interaction.MenuInteraction();
            }
            Console.Clear();
            Console.WriteLine("Good day");
            Thread.Sleep(1000);






        }
    }
}