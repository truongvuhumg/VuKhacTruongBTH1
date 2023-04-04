using BTH20_02.Data;
using BTH20_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTH20_02.Controllers
{
    public class PersonController : Controller
    {
        // khai bao DBcontext de lam viec voi database
        private readonly ApplicationDbContext _context;
        public PersonController ( ApplicationDbContext context)
        {
            _context = context;
        }
        // action tra ve view hien thi danh sach sinh vien
        public async Task<IActionResult> Index()
        {
            var model = await _context.Person.ToListAsync();
            return View(model);
        }
        // action tra ve view them moi sinh vien
        public IActionResult Create()
        {
            return View();
        }
         //action xu ly du lieu sinh vien gui len tu view va luu vao database
        [HttpPost]
        public async Task<IActionResult> Create(Person Pr)
        {
            if(ModelState.IsValid)
            {
                _context.Add(Pr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Pr);
        }
        public async Task<IActionResult> Edit(string id)
        {
            if ( id== null)
            {
                return View("NotFound");
            }
            var person = await _context.Person.FindAsync(id);
            if(person == null)
            {
                return View("NotFound");
            }
            return View(person);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (string id,[Bind("PersonID,PersonName,PersonAddress,PesonAge")] Person pr )
        {
            if(id!= pr.PersonID)
            {
                return View("NotFound");
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(pr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!PersonExists(pr.PersonID))
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
            return View(pr);
        }
        public async Task<IActionResult> Delete (string id)
        {
            if(id == null)
            {
                return View("NotFound");
            }
            var pr = await _context.Person.FirstOrDefaultAsync(m => m.PersonID == id);
            if(pr== null)
            {
                return View("NotFound");
            }
            return View(pr);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (string id)
        {
            var Pr = await _context.Person.FindAsync(id);
            _context.Person.Remove(Pr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool PersonExists (string id )
        {
            return _context.Person.Any(e  => e.PersonID == id);
        }
    }
}