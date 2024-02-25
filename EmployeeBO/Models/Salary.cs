using System;
using System.Collections.Generic;

namespace EmployeeManagementBO.Models
{
    public partial class Salary
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int Amount { get; set; }
        public string Month { get; set; } = null!;
        public int? Year { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
