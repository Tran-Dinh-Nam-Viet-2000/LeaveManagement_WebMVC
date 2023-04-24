using AutoMapper;
using LeaveManagement_WebMVC.Contracts;
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
        private readonly IRepositories<LeaveType> _repositories;

        public LeaveTypeService(ApplicationDbContext dbContext, IMapper mapper, IRepositories<LeaveType> repositories)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _repositories = repositories;
        }
        
        public async Task<IEnumerable<LeaveTypeModel>> GetAll()
        {
            var query = _mapper.Map<List<LeaveTypeModel>>(await _repositories.GetAllAsync());
            return query;
        }
        
        public async Task<LeaveType> Details(int id)
        {
            var query = await _repositories.GetById(id);
            return query;
        }

        public void Create(CreateLeaveTypeModel createLeaveTypeModel)
        {
            //Dùng mapper để convert CreateLeaveTypeModel sang LeaveType, createLeaveTypeModel là object
            //Map<Chuyển về kiểu gì>(đối tượng chuyển)
            var create = _mapper.Map<LeaveType>(createLeaveTypeModel);
            create.DateCreated = DateTime.Now;
            _repositories.CreateAsync(create);
        }

        public void Update(int id, UpdateLeaveTypeModel updateLeaveType)
        {
            var update = _mapper.Map<LeaveType>(updateLeaveType);
            update.DateModified = DateTime.Now;
            _repositories.UpdateAsync(update);
        }

        public void Delete(int id)
        {
            var query = _dbContext.LeaveTypes.FirstOrDefault(x => x.Id == id);
            _repositories.Delete(id);
        }
    }
}
