using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Web.Data;
using Shop.Web.Data.Entities;

namespace Shop.Web.Controllers
{
    public class MechanicalsController : Controller
    {
        private readonly DataContext _context;

        public MechanicalsController(DataContext context)
        {
            _context = context;
        }

        // GET: Mechanicals
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Mechanical.Include(m => m.AccountType);
            return View(await dataContext.ToListAsync());
        }

        // GET: Mechanicals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mechanical = await _context.Mechanical
                .Include(m => m.AccountType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mechanical == null)
            {
                return NotFound();
            }

            return View(mechanical);
        }

        // GET: Mechanicals/Create
        public IActionResult Create()
        {
            ViewData["AccountTypeId"] = new SelectList(_context.DocType, "Id", "Name");
            return View();
        }

        // POST: Mechanicals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountNumber,AccountTypeId,Name,LastName,Surname,LastSurname,Cellphonenumber,Address,Email,Status")] Mechanical mechanical)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mechanical);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountTypeId"] = new SelectList(_context.DocType, "Id", "Name", mechanical.AccountTypeId);
            return View(mechanical);
        }

        // GET: Mechanicals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mechanical = await _context.Mechanical.FindAsync(id);
            if (mechanical == null)
            {
                return NotFound();
            }
            ViewData["AccountTypeId"] = new SelectList(_context.DocType, "Id", "Name", mechanical.AccountTypeId);
            return View(mechanical);
        }

        // POST: Mechanicals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccountNumber,AccountTypeId,Name,LastName,Surname,LastSurname,Cellphonenumber,Address,Email,Status")] Mechanical mechanical)
        {
            if (id != mechanical.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mechanical);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MechanicalExists(mechanical.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountTypeId"] = new SelectList(_context.DocType, "Id", "Name", mechanical.AccountTypeId);
            return View(mechanical);
        }

        // GET: Mechanicals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mechanical = await _context.Mechanical
                .Include(m => m.AccountType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mechanical == null)
            {
                return NotFound();
            }

            return View(mechanical);
        }

        // POST: Mechanicals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mechanical = await _context.Mechanical.FindAsync(id);
            _context.Mechanical.Remove(mechanical);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MechanicalExists(int id)
        {
            return _context.Mechanical.Any(e => e.Id == id);
        }
    }
}
