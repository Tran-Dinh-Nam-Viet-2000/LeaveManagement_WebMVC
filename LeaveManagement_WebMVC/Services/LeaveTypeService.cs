using LeaveManagement_WebMVC.Data;
using LeaveManagement_WebMVC.Models;
using LeaveManagement_WebMVC.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement_WebMVC.Services
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly ApplicationDbContext _dbContext;

        public LeaveTypeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LeaveType> Create(LeaveTypeModel leaveTypeModel)
        {
            var create = new LeaveType
            {
                Name = leaveTypeModel.Name,
                DefaultDays = leaveTypeModel.DefaultDays,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
            };
            _dbContext.LeaveTypes.Add(create);
            await _dbContext.SaveChangesAsync();
            return create;
        }

        public void Delete(int id)
        {
            var query = _dbContext.LeaveTypes.FirstOrDefault(x => x.Id == id);
            _dbContext.LeaveTypes.Remove(query);
            _dbContext.SaveChanges();
        }

        public async Task<LeaveType> Details(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var query = await _dbContext.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (query == null)
            {
                return null;
            }
            return query;
        }

        public async Task<IEnumerable<LeaveType>> GetAll()
        {
            var query = await _dbContext.LeaveTypes.OrderByDescending(t => t.Id).ToListAsync();
            return query;
        }

        public async Task<LeaveType> Update(int? id, LeaveTypeModel leaveTypeModel)
        {
            if (id == null)
            {
                return null;
            }
            var query = _dbContext.LeaveTypes.FirstOrDefault(x => x.Id == id);
            if (query == null)
            {
                return null;
            }
            query.Name = leaveTypeModel.Name;
            query.DefaultDays = leaveTypeModel.DefaultDays;
            query.DateModified = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return query;
        }
    }
}
