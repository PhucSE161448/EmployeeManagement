using EmployeeManagementBO.Models;
using EmployeeManagementDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementRepo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public List<Employee> GetEmployees() => EmployeeDAO.Instance.GetEmployees();
        public List<Employee> SearchEmployee(Expression<Func<Employee, bool>>? filter = null) => EmployeeDAO.Instance.SearchEmployees(filter);
        public bool AddEmployee(Employee employee) => EmployeeDAO.Instance.AddEmployee(employee);
        public bool DeleteEmployee(int id) => EmployeeDAO.Instance.DeleteEmployee(id);
        public bool EditEmployee(Employee employee) => EmployeeDAO.Instance.EditEmployee(employee);
        public Employee GetEmployeeById(int id) => EmployeeDAO.Instance.GetEmployeeById(id);
        public Employee CheckLogin(int userNo, string password) => EmployeeDAO.Instance.CheckLogin(userNo, password);
    }
}
