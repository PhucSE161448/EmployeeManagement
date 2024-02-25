using EmployeeManagementBO.Models;
using EmployeeManagementDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeManagementRepo
{
    public class DepartmentRepo : IDepartmentRepo
    {

        public List<Department> GetDepartments() => DepartmentDAO.Instance.GetDepartments();

        public bool AddDepartment(Department Department) => DepartmentDAO.Instance.AddDepartment(Department);
        public bool DeleteDepartment(int id) => DepartmentDAO.Instance.DeleteDepartment(id);
        public bool EditDepartment(Department Department) => DepartmentDAO.Instance.EditDepartment(Department);
    }
}
