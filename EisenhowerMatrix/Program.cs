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
            while (run)
            {
                Console.Clear();

                View view = new View();
                Input input = new Input();
                view.MainScrean(todoMatrix);
                int option = input.GameOption();
                switch (option)
                {
                    case 1:
                        MenuAddTask(view, input, todoMatrix);

                        break;
                    case 5:
                        run = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong choice");
                        Thread.Sleep(1000);
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine("Good day");
            Thread.Sleep(1000);






        }



        private static void MenuAddTask(View view, Input input, TodoMatrix matrix)
        {
            bool readyToAdd = false;
            string title = " ";
            string deadline = "dd-MM";
            string important = "Y/N";
            while (!readyToAdd)
            {
                view.AddTaskView(title, deadline, important);
                Console.WriteLine();
                if (title == " ")
                {
                    Console.WriteLine("Add title: ");
                    title = input.InputTitle();
                }
                else if (deadline == "dd-MM")
                {
                    Console.WriteLine("Add deadline: ");
                    deadline = input.InputDadeline();
                }
                else if (important == "Y/N")
                {
                    Console.WriteLine("Is it important: ");
                    important = input.InputImportance();
                }
                else
                    readyToAdd = true;

            }
            string format = "dd-MM";

            DateTime parsedDate;

            DateTime.TryParseExact(deadline, format, null, System.Globalization.DateTimeStyles.None, out parsedDate);

            if (important == "Y")
            {
                matrix.AddItem(title, parsedDate, true);
            }
            else
            {
                matrix.AddItem(title, parsedDate, false);
            }

        }
    }
}