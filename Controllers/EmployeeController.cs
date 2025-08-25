using HrManagement.Data;
using HrManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private  readonly HRManagementDbContext db;
        public EmployeeController(HRManagementDbContext context)
        {
            this.db = context;
        }
        [HttpGet]
        public async Task<IActionResult >Index()
        {
            var Employees = await db.Employees.Include(e => e.Department).ToListAsync();
            return View(Employees);
        }
        
        public async Task<IActionResult> Create()
        {
            ViewBag.Departments = await db.Departments.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(Employee obj)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = await db.Departments.ToListAsync();
                return View(obj);
            }
            db.Employees.Add(obj);
            await db.SaveChangesAsync();
            TempData["Success"] = "Employee Added Successfully";
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) {
                return NotFound();
            }
            var Employee = await db.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e=>e.Emp_Id == id);
            if (Employee == null) {
                return NotFound();
            }
            return View(Employee);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var Employee = await db.Employees.Include(e => e.Department)
                                              .FirstOrDefaultAsync(e => e.Emp_Id == id);
            if(Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var employee = await db.Employees.FindAsync(id);
            if (employee  == null)
            {
                return NotFound();

            }
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
            TempData["Success"] = "Employee Deleted Successfully";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Departments = await db.Departments.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }
            var Employee = await db.Employees.Include(e => e.Department)
                                              .FirstOrDefaultAsync(e => e.Emp_Id == id);
            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee obj)
        {
            ViewBag.Departments = await db.Departments.ToListAsync();
            if (ModelState.IsValid)
            {
                db.Employees.Update(obj);
                await db.SaveChangesAsync();
                TempData["Success"] = "Employee Edited  Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
