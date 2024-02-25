using EmployeeManagementBO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDAO
{
    public class EmployeeDAO
    {
        private readonly EmployeeManagementContext _db = null;
        public static EmployeeDAO instance = null;

        public static EmployeeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeDAO();
                }
                return instance;
            }
        }
        public EmployeeDAO()
        {
            _db = new EmployeeManagementContext();
        }

        public List<Employee> GetEmployees()
        {
            return _db.Employees.Include(x => x.Department).ToList();
        }
        public List<Employee> SearchEmployees(Expression<Func<Employee, bool>>? filter = null)
        {
            IQueryable<Employee> query = _db.Employees;
            if (filter != null)
            {
                query = query.Include(x => x.Department).Where(filter);
            }
            return  query.ToList();
        }

        public bool AddEmployee(Employee Employee)
        {
            try
            {
                _db.Add(Employee);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteEmployee(int id)
        {
            Employee Employee = GetEmployeeById(id);
            try
            {
                _db.Employees.Remove(Employee);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Employee GetEmployeeById(int id)
        {
            return _db.Employees.FirstOrDefault(x => x.Id == id);
        }

        public Employee CheckLogin(int userNo, string password)
        {
            return _db.Employees.FirstOrDefault(x => x.UserNo == userNo  && x.Password == password);
        }
        public bool EditEmployee(Employee Employee)
        {
            Employee de = GetEmployeeById(Employee.Id);
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
