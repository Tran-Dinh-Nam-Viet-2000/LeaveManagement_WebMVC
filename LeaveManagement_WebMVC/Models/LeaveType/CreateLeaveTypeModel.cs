namespace LeaveManagement_WebMVC.Models.LeaveType
{
    public class CreateLeaveTypeModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
