using AutoMapper;
using LeaveManagement_WebMVC.Data;
using LeaveManagement_WebMVC.Models.LeaveType;
using LeaveManagement_WebMVC.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement_WebMVC.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILeaveTypeService _leaveTypeService;
        private readonly IMapper _mapper;

        public LeaveTypesController(ApplicationDbContext dbContext, ILeaveTypeService leaveTypeService, IMapper mapper)
        {
            _dbContext = dbContext;
            _leaveTypeService = leaveTypeService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _leaveTypeService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var query = await _leaveTypeService.Details(id);
            if (query == null)
            {
                return NotFound();
            }
            return View(query);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateLeaveTypeModel createLeaveTypeModel)
        {
            var scope = _mapper.Map<LeaveType>(createLeaveTypeModel);
            _leaveTypeService.Create(createLeaveTypeModel);
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(scope);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var query = await _dbContext.LeaveTypes.FirstOrDefaultAsync(n => n.Id == id);
            return View(query);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, UpdateLeaveTypeModel updateLeaveType)
        {
            var mapping = _mapper.Map<LeaveType>(updateLeaveType);
            _leaveTypeService.Update(id, updateLeaveType);
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(mapping);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) 
            {
                return NotFound();
            }
            var query = _dbContext.LeaveTypes.FirstOrDefault(x => x.Id == id);
            if (query == null) return NotFound(); 
            return View(query);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _leaveTypeService.Delete(id);
            return RedirectToAction("Index");
        }
    }

}
