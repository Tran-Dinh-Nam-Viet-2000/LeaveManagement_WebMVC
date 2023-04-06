using LeaveManagement_WebMVC.Data;
using LeaveManagement_WebMVC.Models;

namespace LeaveManagement_WebMVC.Services.IServices
{
    public interface ILeaveTypeService
    {
        Task<IEnumerable<LeaveType>> GetAll();
        Task<LeaveType> Details(int? id);
        Task<LeaveType> Create(LeaveTypeModel leaveTypeModel);
        Task<LeaveType> Update(int? id, LeaveTypeModel leaveTypeModel);
        void Delete(int id);
    }
}
