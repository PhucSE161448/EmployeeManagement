using EmployeeManagementBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementService
{
    public interface ISalaryService
    {
        public List<Salary> GetSalarys();
        public List<Salary> SearchSalarys(Expression<Func<Salary, bool>>? filter = null);
        public bool AddSalary(Salary salary);
        public bool DeleteSalary(int id);
        public bool EditSalary(Salary salary);
    }
}
