using EmployeeManagementBO.Models;
using EmployeeManagementDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task = EmployeeManagementBO.Models.Task;

namespace EmployeeManagementRepo
{
    public class TaskRepo : ITaskRepo
    {
        public List<Task> GetTasks() => TaskDAO.Instance.GetTasks();
        public List<Task> SearchTask(Expression<Func<Task, bool>>? filter = null) => TaskDAO.Instance.SearchTasks(filter);
        public bool AddTask(Task task) => TaskDAO.Instance.AddTask(task);
        public bool DeleteTask(int id) => TaskDAO.Instance.DeleteTask(id);
        public bool EditTask(Task task) => TaskDAO.Instance.EditTask(task);
    }
}
