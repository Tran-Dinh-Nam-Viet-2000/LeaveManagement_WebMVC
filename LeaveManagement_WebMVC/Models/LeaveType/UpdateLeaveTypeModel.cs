using LeaveManagement_WebMVC.Data.Base;

namespace LeaveManagement_WebMVC.Models.LeaveType
{
    public class UpdateLeaveTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DefaultDays { get; set; }
        public DateTime DateModified { get; set; }
    }
}
