using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class TaskDetailModel
    {
        public int Id { get; set; }
        public int UserNo { get; set; }
        public int EmployeeId { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskDeliveryDate { get; set; }
        public string Name { get; set; }
        public string? TaskContent { get; set; }
        public string TaskTitle { get; set; }
    }
}
