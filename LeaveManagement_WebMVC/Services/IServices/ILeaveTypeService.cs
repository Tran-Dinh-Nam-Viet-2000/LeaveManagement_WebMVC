using LeaveManagement_WebMVC.Data;
using LeaveManagement_WebMVC.Models.LeaveType;

namespace LeaveManagement_WebMVC.Services.IServices
{
    public interface ILeaveTypeService
    {
        Task<IEnumerable<LeaveTypeModel>> GetAll();
        Task<LeaveType> Details(int? id);
        void Create(CreateLeaveTypeModel createLeaveTypeModel);
        void Update(int id, UpdateLeaveTypeModel updateLeaveType);
        void Delete(int id);
    }
}
