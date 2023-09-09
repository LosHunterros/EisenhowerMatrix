using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Configuration;
using NLog.Internal;

namespace EisenhowerMain
{
    public class DataManager
    {
        private string ConnectionString => ConfigurationManager.AppSettings["connectionString"];
        private ITasksDao tasksDao;

        public DataManager()
        {
            var isConnected = TestConnection();
            Console.WriteLine(isConnected);

            tasksDao = new TasksDao(ConnectionString);

        }

        public bool TestConnection()
        {
            using var connection = new SqlConnection(ConnectionString);

            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void DisplayTasks(TodoMatrix matrix)
        {
            var allTasks = tasksDao.GetAllTasks();
            foreach (var task in allTasks)
            {
                TodoItem item = task.Item2 as TodoItem;
                matrix.AddItem(item.Title, item.Deadline, task.Item3);
            }

        }

        public void AddNewTask(TodoItem task, bool isImportant)
        {

            tasksDao.AddTask(task, isImportant);

        }



    }
}
