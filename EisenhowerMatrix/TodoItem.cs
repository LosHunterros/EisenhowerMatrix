using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMain
{
    internal class TodoItem
    {
        private readonly string Title;

        private readonly DateTime Deadline;

        public bool IsDone;

        public TodoItem(string title, DateTime deadline)
        {
            Title = title;
            Deadline = deadline;
            IsDone = false;
        }

        private string GetTitle() { return Title; }
        private DateTime GetDeadLine() { return Deadline; }
        public void Mark() { IsDone = true; }
        public void Unmark() { IsDone = false; }
        public string CurrentTitle { get { return GetTitle(); } }
        public override string ToString()
        {
            string title = GetTitle();
            string deadline = GetDeadLine().ToString("dd-MM");
            string mark = IsDone ? "[X]" : "[ ]";
            return $"{mark} {deadline} {title}";
        }


    }
}