using System;
using System.Collections.Generic;

namespace EmployeeManagementBO.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Title { get; set; } = null!;
        public string? Content { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
