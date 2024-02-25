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
    public class SalaryRepo : ISalaryRepo
    {
        public List<Salary> GetSalarys() => SalaryDAO.Instance.GetSalarys();
        public List<Salary> SearchSalary(Expression<Func<Salary, bool>>? filter = null) => SalaryDAO.Instance.SearchSalarys(filter);
        public bool AddSalary(Salary salary) => SalaryDAO.Instance.AddSalary(salary);
        public bool DeleteSalary(int id) => SalaryDAO.Instance.DeleteSalary(id);
        public bool EditSalary(Salary salary) => SalaryDAO.Instance.EditSalary(salary);
    }
}
