using AutoMapper;
using LeaveManagement_WebMVC.Data;
using LeaveManagement_WebMVC.Models.LeaveType;
using LeaveManagement_WebMVC.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement_WebMVC.Services
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public LeaveTypeService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<LeaveTypeModel>> GetAll()
        {
            var query = _mapper.Map<List<LeaveTypeModel>>(await _dbContext.LeaveTypes.OrderByDescending(t => t.Id).ToListAsync());
            return query;
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

        public void Create(CreateLeaveTypeModel createLeaveTypeModel)
        {
            //Dùng mapper để convert CreateLeaveTypeModel sang LeaveType, createLeaveTypeModel là object
            //Map<Chuyển về kiểu gì>(đối tượng chuyển)
            var create = _mapper.Map<LeaveType>(createLeaveTypeModel);
            create.DateCreated = DateTime.Now;
            _dbContext.LeaveTypes.Add(create);
            _dbContext.SaveChanges();
        }

        public void Update(int id, UpdateLeaveTypeModel updateLeaveType)
        {
            var update = _mapper.Map<LeaveType>(updateLeaveType);
            update.DateModified = DateTime.Now;
            _dbContext.Update(update);
            _dbContext.SaveChanges();;
        }

        public void Delete(int id)
        {
            var query = _dbContext.LeaveTypes.FirstOrDefault(x => x.Id == id);
            _dbContext.LeaveTypes.Remove(query);
            _dbContext.SaveChanges();
        }
    }
}
