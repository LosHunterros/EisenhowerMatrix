using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMain
{
    internal interface ITasksDao
    {
        public void AddTask(TodoItem task);

        public void UpdateTask(int id);

        public void DeleteTask(TodoItem task);

        public List<Task> GetAllTasks();

        public Task GetTasks(int id);
    }
}
