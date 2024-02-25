using EmployeeManagementBO.Models;
using EmployeeManagementRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo departmentRepo = null;
        public DepartmentService()
        {
            departmentRepo = new DepartmentRepo();
        }

        public List<Department> GetDepartments()
        {
            return departmentRepo.GetDepartments();
        }

        public bool AddDepartment(Department Department)
        {
            return departmentRepo.AddDepartment(Department);
        }
        public bool DeleteDepartment(int id)
        {
            return departmentRepo.DeleteDepartment(id);
        }
        public bool EditDepartment(Department Department)
        {
            return departmentRepo.EditDepartment(Department);
        }

    }
}
