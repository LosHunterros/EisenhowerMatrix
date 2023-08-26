using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMain
{
    internal class TodoQuarter
    {
        public readonly List<TodoItem> TodoItems;
        public int ActiveTaskIndex = 0;


        public TodoQuarter()
        {
            TodoItems = new List<TodoItem>();
        }
        public void AddItem(string title, DateTime deadline)
        {
            TodoItems.Add(new TodoItem(title, deadline));
        }
        public void RemoveItem(int index)
        {
            TodoItems.RemoveAt(index);
        }
        public void ArchiveItems()
        {
            for (int i = TodoItems.Count - 1; i >= 0; i--)
            {
                if (GetItem(i).IsDone)
                {
                    RemoveItem(i);
                }
            }
        }

        public TodoItem GetItem(int index)
        {
            return TodoItems[index];
        }

        private List<TodoItem> GetItems()
        {
            return TodoItems;
        }

        public void GoUpTaskList()
        {
            if (ActiveTaskIndex > 0)
            {
                ActiveTaskIndex--;
            }
            else
            {
                ActiveTaskIndex = TodoItems.Count() - 1;
            }
        }

        public void GoDownTaskList()
        {
            if (ActiveTaskIndex < TodoItems.Count() - 1)
            {
                ActiveTaskIndex++;
            }
            else ActiveTaskIndex = 0;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<TodoItem> items = GetItems();
            foreach (TodoItem item in items)
            {
                stringBuilder.Append(item.ToString() + "\n");
            }
            return stringBuilder.ToString();
        }
    }
}
