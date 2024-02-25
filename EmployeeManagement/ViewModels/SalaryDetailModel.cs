using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class SalaryDetailModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int UserNo { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string MonthName { get; set; }
        public int? Year { get; set; }
    }
}
