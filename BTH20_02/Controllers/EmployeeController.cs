using BTH20_02.Data;
using BTH20_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTH20_02.Controllers

{
    public class EmployeeController : Controller{
        private readonly ApplicationDbContext _context;
        public EmployeeController (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.Employee.ToListAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Employee std)
        {
            if(ModelState.IsValid)
            {
                _context.Add(std);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(std);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if( id == null)
            {
                return View("NotFound");
            }

            var employee = await _context.Employee.FindAsync(id);
            if(employee == null)
            {
                return View("NotFound");
            }
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
// Edit
        public async Task<IActionResult> Edit(string id, [Bind("EmployeeID,EmployeeName,EmployeeAddress")] Employee std)
        {
            if(id != std.EmployeeID)
            {
                return View("NotFound");
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(std);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!EmployeeExists(std.EmployeeID))
                    {
                        return View("NotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(std);
        }
        //Delelte
            public async Task<IActionResult> Delete(string id)
        {
            if(id == null)
            {
                return View("NotFound");
            }

            var std = await _context.Employee.FirstOrDefaultAsync(m => m.EmployeeID ==id);
            if(std == null)
            {
                return View("NotFound");
            }
            return View(std);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            var std = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(std);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool EmployeeExists(string id)
        {
            return _context.Employee.Any(e => e.EmployeeID ==id);
        }


    }
}