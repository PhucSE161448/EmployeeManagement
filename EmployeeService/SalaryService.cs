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
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepo salaryRepo = null;
        public SalaryService()
        {
            salaryRepo = new SalaryRepo();
        }

        public List<Salary> GetSalarys()
        {
            return salaryRepo.GetSalarys();
        }
        public List<Salary> SearchSalarys(Expression<Func<Salary, bool>>? filter = null)
        {
            return salaryRepo.SearchSalary(filter);
        }
        public bool AddSalary(Salary salary)
        {
            return salaryRepo.AddSalary(salary);
        }
        public bool DeleteSalary(int id)
        {
            return salaryRepo.DeleteSalary(id);
        }
        public bool EditSalary(Salary salary)
        {
            return salaryRepo.EditSalary(salary);
        }   
    }
}
