using System;
using System.Collections.Generic;

namespace EmployeeManagementBO.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Salaries = new HashSet<Salary>();
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public int UserNo { get; set; }
        public string Name { get; set; } = null!;
        public int DepartmentId { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<Salary> Salaries { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
