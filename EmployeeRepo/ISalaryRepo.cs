using EmployeeManagementBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementRepo
{
    public interface ISalaryRepo
    {
        public List<Salary> GetSalarys();
        public bool AddSalary(Salary salary);
        public bool DeleteSalary(int id);
        public bool EditSalary(Salary salary);
        public List<Salary> SearchSalary(Expression<Func<Salary, bool>>? filter = null);
    }
}
