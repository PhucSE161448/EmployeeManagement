using EmployeeManagementBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementService
{
    public interface IDepartmentService
    {
        public List<Department> GetDepartments();
        public bool AddDepartment(Department Department);
        public bool DeleteDepartment(int id);
        public bool EditDepartment(Department Department);
    }
}
