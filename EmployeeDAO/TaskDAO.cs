using EmployeeManagementBO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task = EmployeeManagementBO.Models.Task;

namespace EmployeeManagementDAO
{
    public class TaskDAO
    {
        private readonly EmployeeManagementContext _db = null;
        public static TaskDAO instance = null;

        public static TaskDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaskDAO();
                }
                return instance;
            }
        }
        public TaskDAO()
        {
            _db = new EmployeeManagementContext();
        }

        public List<Task> GetTasks()
        {
            return _db.Tasks.Include(x => x.Employee).ToList();
        }
        public List<Task> SearchTasks(Expression<Func<Task, bool>>? filter = null)
        {
            IQueryable<Task> query = _db.Tasks;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.ToList();
        }
        public bool AddTask(Task task)
        {
            try
            {
                _db.Add(task);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteTask(int id)
        {
            Task task = GetTaskById(id);
            try
            {
                _db.Tasks.Remove(task);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Task GetTaskById(int id)
        {
            return _db.Tasks.FirstOrDefault(x => x.Id == id);
        }

 
        public bool EditTask(Task task)
        {
            Task de = GetTaskById(task.Id);
            try
            {
                _db.Update(de);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
