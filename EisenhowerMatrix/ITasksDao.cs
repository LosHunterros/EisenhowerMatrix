using EisenhowerMain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMain
{
    internal interface ITasksDao
    {
        public void AddTask(TodoItem task, bool isImportant);

        public void UpdateTask(int id);

        public void DeleteTask(TodoItem task);

        public List<Tuple<int, TodoItem, bool>> GetAllTasks();

        public TodoItem GetTask(int id);
    }
}
