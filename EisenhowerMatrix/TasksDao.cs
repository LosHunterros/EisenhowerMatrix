using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMain
{
    internal class TasksDao : ITasksDao
    {
        private readonly string connectionString;

        public TasksDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddTask(TodoItem task, bool isImportant)
        {
            const string addTaskCommand = @"INSERT INTO tasks (Title, Deadline, Important, Done) VALUES (@task_title, @date, @task_importance, @status)";
            try
            {
                using var connection = new SqlConnection(connectionString);
                var cmd = new SqlCommand(addTaskCommand, connection);
                cmd.Parameters.AddWithValue("@task_title", task.Title);
                cmd.Parameters.AddWithValue("@date", task.Deadline.ToString("dd-MM-yyyy"));
                cmd.Parameters.AddWithValue("@task_importance", Convert.ToByte(isImportant));
                cmd.Parameters.AddWithValue("@status", Convert.ToByte(task.IsDone));
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                cmd.ExecuteScalar();
            }
            catch (SqlException e)
            {
                throw new RuntimeWrappedException(e);
            }



        }


        public void DeleteTask(TodoItem task)
        {
            throw new NotImplementedException();
        }

        public List<Tuple<int, TodoItem, bool>> GetAllTasks()
        {
            const string getAllCommand = @"SELECT Id, Title, Deadline, Important, Done FROM tasks";

            try
            {
                var allTasks = new List<Tuple<int, TodoItem, bool>>();

                using var connection = new SqlConnection(connectionString);
                var cmd = new SqlCommand(getAllCommand, connection);

                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                var reader = cmd.ExecuteReader();

                if (!reader.HasRows) return allTasks;

                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var title = reader["Title"] as string;
                    var deadline = (DateTime)reader["Deadline"];
                    var isImportant = Convert.ToBoolean(reader["Important"]);
                    var isDone = Convert.ToBoolean(reader["Done"]);


                    var Task = new TodoItem(title, deadline, isDone);
                    allTasks.Add(new Tuple<int, TodoItem, bool>(id, Task, isImportant));
                }

                return allTasks;
            }
            catch (SqlException e)
            {
                throw new RuntimeWrappedException(e);
            }

        }



        public TodoItem GetTask(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(int id)
        {
            throw new NotImplementedException();
        }
    }
}
