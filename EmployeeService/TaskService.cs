using EmployeeManagementBO.Models;
using EmployeeManagementRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task = EmployeeManagementBO.Models.Task;

namespace EmployeeManagementService
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepo TaskRepo = null;
        public TaskService()
        {
            TaskRepo = new TaskRepo();
        }

        public List<Task> GetTasks()
        {
            return TaskRepo.GetTasks();
        }
        public List<Task> SearchTasks(Expression<Func<Task, bool>>? filter = null)
        {
            return TaskRepo.SearchTask(filter);
        }
        public bool AddTask(Task task)
        {
            return TaskRepo.AddTask(task);
        }
        public bool DeleteTask(int id)
        {
            return TaskRepo.DeleteTask(id);
        }
        public bool EditTask(Task task)
        {
            return TaskRepo.EditTask(task);
        }
    }
}
