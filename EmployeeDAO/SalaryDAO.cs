using EmployeeManagementBO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EmployeeManagementDAO
{
    public class SalaryDAO
    {
        private readonly EmployeeManagementContext _context = null;
        public static SalaryDAO instance = null;
        public static SalaryDAO Instance {
            get 
            { 
                if(instance == null)
                {
                    instance = new SalaryDAO();
                }
                return instance; 
            }
        }

        public SalaryDAO() {
            _context = new EmployeeManagementContext();
        }
        public List<Salary> GetSalarys()
        {
            return _context.Salaries.Include(x => x.Employee).ToList();
        }
        public List<Salary> SearchSalarys(Expression<Func<Salary, bool>>? filter = null)
        {
            IQueryable<Salary> query = _context.Salaries;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.ToList();
        }
        public bool AddSalary(Salary salary)
        {
            try
            {
                _context.Add(salary);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteSalary(int id)
        {
            Salary salary = GetSalaryById(id);
            try
            {
                _context.Salaries.Remove(salary);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Salary GetSalaryById(int id)
        {
            return _context.Salaries.FirstOrDefault(x => x.Id == id);
        }


        public bool EditSalary(Salary salary)
        {
            Salary de = GetSalaryById(salary.Id);
            try
            {
                _context.Update(de);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
