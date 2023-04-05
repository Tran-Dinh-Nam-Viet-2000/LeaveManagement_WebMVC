using LeaveManagement_WebMVC.Data.Base;

namespace LeaveManagement_WebMVC.Data
{
    public class LeaveType : BaseEntity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
