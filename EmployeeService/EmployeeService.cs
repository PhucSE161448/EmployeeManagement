using EmployeeManagementBO.Models;
using EmployeeManagementRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _repo = null;
        public EmployeeService()
        {
            _repo = new EmployeeRepo();
        }
        public List<Employee> GetEmployees()
        {
            return _repo.GetEmployees();
        }
        public List<Employee> SearchEmployee(Expression<Func<Employee, bool>>? filter = null)
        {
            return _repo.SearchEmployee(filter);
        }
        public bool AddEmployee(Employee employee)
        {
            return _repo.AddEmployee(employee);
        }
        public bool DeleteEmployee(int id)
        {
            return _repo.DeleteEmployee(id);
        }
        public bool EditEmployee(Employee employee)
        {
            return _repo.EditEmployee(employee);
        }

        public Employee CheckLogin(int userNo, string password)
        {
            return _repo.CheckLogin(userNo, password);
        }
        public Employee GetEmployeeById(int id) {
            return _repo.GetEmployeeById(id);
        }
    }
}
