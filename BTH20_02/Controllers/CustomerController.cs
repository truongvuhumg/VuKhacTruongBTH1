using BTH20_02.Data;
using BTH20_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTH20_02.Controllers

{
    public class CustomerController : Controller{
        private readonly ApplicationDbContext _context;
        public CustomerController (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.Customer.ToListAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Customer std)
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

            var customer = await _context.Customer.FindAsync(id);
            if(customer == null)
            {
                return View("NotFound");
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
// Edit
        public async Task<IActionResult> Edit(string id, [Bind("CustomerID,CustomerName,CustomerAddress,CustomerPhone")] Customer std)
        {
            if(id != std.CustomerID)
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
                    if(!CustomerExists(std.CustomerID))
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

            var std = await _context.Customer.FirstOrDefaultAsync(m => m.CustomerID ==id);
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

            var std = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(std);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool CustomerExists(string id)
        {
            return _context.Customer.Any(e => e.CustomerID ==id);
        }


    }
}