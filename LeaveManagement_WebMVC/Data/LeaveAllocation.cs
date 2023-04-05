using LeaveManagement_WebMVC.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement_WebMVC.Data
{
    public class LeaveAllocation : BaseEntity
    {
        public int NumberOfDays { get; set; }

        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public string EmployeeId { get; set; }
    }
}
