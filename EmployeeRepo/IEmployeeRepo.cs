using EmployeeManagementBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementRepo
{
    public interface IEmployeeRepo
    {
        public List<Employee> GetEmployees();
        public List<Employee> SearchEmployee(Expression<Func<Employee, bool>>? filter = null);
        public bool AddEmployee(Employee employee);
        public bool DeleteEmployee(int id);
        public bool EditEmployee(Employee employee);
        public Employee GetEmployeeById(int id);
        public Employee CheckLogin(int userNo, string password);
    }
}
