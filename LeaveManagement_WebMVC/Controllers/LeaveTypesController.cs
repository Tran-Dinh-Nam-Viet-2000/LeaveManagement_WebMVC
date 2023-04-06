using LeaveManagement_WebMVC.Data;
using LeaveManagement_WebMVC.Models;
using LeaveManagement_WebMVC.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LeaveManagement_WebMVC.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypesController(ApplicationDbContext dbContext, ILeaveTypeService leaveTypeService)
        {
            _dbContext = dbContext;
            _leaveTypeService = leaveTypeService;
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
        public async Task<IActionResult> Create(LeaveTypeModel leaveTypeModel)
        {
            var create = await _leaveTypeService.Create(leaveTypeModel);
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(create);
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, LeaveTypeModel leaveTypeModel)
        {
            var update = await _leaveTypeService.Update(id, leaveTypeModel);
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(update);
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
