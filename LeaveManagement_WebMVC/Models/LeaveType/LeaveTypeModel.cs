using System.ComponentModel.DataAnnotations;

namespace LeaveManagement_WebMVC.Models.LeaveType
{
    public class LeaveTypeModel
    {
        public int Id { get; set; }

        [Display(Name = "Leave type name")]
        public string Name { get; set; }

        [Display(Name = "Default number of day")]
        public int DefaultDays { get; set; }
    }
}
