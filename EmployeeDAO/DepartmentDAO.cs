using EmployeeManagementBO.Models;
using EmployeeManagementBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementDAO
{
    public class DepartmentDAO
    {
        private readonly EmployeeManagementContext _db = null;
        private static DepartmentDAO instance = null;

        public static DepartmentDAO Instance
        {
            get {
                if(instance == null)
                {
                    instance = new DepartmentDAO();
                }
                return instance; 
            }
        }
        public DepartmentDAO()
        {
            _db = new EmployeeManagementContext();
        }

        public List<Department> GetDepartments()
        {
            return _db.Departments.ToList();
        }

        public bool AddDepartment(Department department)
        {
            try
            {
                _db.Add(department);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteDepartment(int id)
        {
            Department department = GetDepartmentById(id);
            try
            {
                _db.Departments.Remove(department);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Department GetDepartmentById(int id)
        {
            return _db.Departments.FirstOrDefault(x => x.Id == id);
        }

        public bool EditDepartment(Department department)
        {
            Department de = GetDepartmentById(department.Id);
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
