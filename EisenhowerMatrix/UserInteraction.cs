using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMain
{
    internal class UserInteraction
    {
        private TodoMatrix _matrix;

        public UserInteraction(TodoMatrix matrix)
        {
            _matrix = matrix;
        }
        public void MenuInteraction()
        {
            bool run = true;

            while (run)
            {

                view.MainScreen(_matrix);

                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                TodoQuarter activeQuarter = _matrix.GetTodoQuarter(_matrix.ActiveQuarterName.ToString());

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        activeQuarter.GoUpTaskList();
                        break;
                    case ConsoleKey.DownArrow:
                        activeQuarter.GoDownTaskList();
                        break;
                    case ConsoleKey.Tab:
                        _matrix.ChangeActiveQuarter();
                        break;
                    case ConsoleKey.Enter:
                        if (activeQuarter.ActiveTaskIndex >= 0 && activeQuarter.ActiveTaskIndex < activeQuarter.TodoItems.Count)
                        {
                            TodoItem activeTask = activeQuarter.GetItem(activeQuarter.ActiveTaskIndex);
                            activeTask.IsDone = !activeTask.IsDone;
                        }
                        break;
                    case ConsoleKey.A:
                        MenuAddTask(view, input, _matrix);
                        break;
                    case ConsoleKey.D:
                        TodoItem taskToRemove = activeQuarter.GetItem(activeQuarter.ActiveTaskIndex);
                        view.RemoveIfSure(taskToRemove.CurrentTitle);
                        if (input.InputConfirmation())
                        {
                            activeQuarter.RemoveItem(activeQuarter.ActiveTaskIndex);
                        }
                        break;
                    case ConsoleKey.S:
                        _matrix.ArchiveItems();
                        break;
                    case ConsoleKey.Escape:
                        run = false;
                        break;
                }
            }
        }
        View view = new View();
        Input input = new Input();
        private static void MenuAddTask(View view, Input input, TodoMatrix _matrix)
        {
            bool readyToAdd = false;
            string title = " ";
            string deadline = "dd-MM";
            string important = "Y/N";
            while (!readyToAdd)
            {
                view.AddTaskView(title, deadline, important);
                // try replace if else with switch
                Console.WriteLine();
                if (title == " ")
                {
                    Console.WriteLine("Add title: ");
                    title = input.InputTitle();
                }
                else if (deadline == "dd-MM")
                {
                    Console.WriteLine("Add deadline: ");
                    deadline = input.InputDeadline();
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


            _matrix.AddItem(title, parsedDate, important == "Y");

        }
    }
}
