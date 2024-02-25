using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeDetailModel
    {
        public int Id { get; set; }
        public int UserNo { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int Salary { get; set; }
        public int Role_Id { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
