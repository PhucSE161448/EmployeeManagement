using EmployeeManagementBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task = EmployeeManagementBO.Models.Task;

namespace EmployeeManagementRepo
{
    public interface ITaskRepo
    {
        public List<Task> GetTasks();
        public List<Task> SearchTask(Expression<Func<Task, bool>>? filter = null);
        public bool AddTask(Task task);
        public bool DeleteTask(int id);
        public bool EditTask(Task task);
    }
}
