using HrManagement.Data;
using HrManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly HRManagementDbContext db;

        public DepartmentController(HRManagementDbContext context)
        {
            this.db = context;
        }

        public async Task<IActionResult> Index()
        {
            var Departments = await db.Departments.ToListAsync();

            return View(Departments);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(Department dept)
        {
            if (ModelState.IsValid) {
                await db.Departments.AddAsync(dept);
                await db.SaveChangesAsync();
                TempData["Success"] = "DepartMent Added SuccessFully";
                return RedirectToAction("Index");
            }
            return View(dept );
        }
    }
}
