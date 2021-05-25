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
    public class PartMastersController : Controller
    {
        private readonly DataContext _context;

        public PartMastersController(DataContext context)
        {
            _context = context;
        }

        // GET: PartMasters
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.PartMaster.Include(p => p.ServiceType);
            return View(await dataContext.ToListAsync());
        }

        // GET: PartMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partMaster = await _context.PartMaster
                .Include(p => p.ServiceType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partMaster == null)
            {
                return NotFound();
            }

            return View(partMaster);
        }

        // GET: PartMasters/Create
        public IActionResult Create()
        {
            ViewData["ServiceTypeId"] = new SelectList(_context.ServiceType, "Id", "Name");
            return View();
        }

        // POST: PartMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ServiceTypeId,Note,Price,MinPrice,MaxPrice,Quantity")] PartMaster partMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceTypeId"] = new SelectList(_context.ServiceType, "Id", "Name", partMaster.ServiceTypeId);
            return View(partMaster);
        }

        // GET: PartMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partMaster = await _context.PartMaster.FindAsync(id);
            if (partMaster == null)
            {
                return NotFound();
            }
            ViewData["ServiceTypeId"] = new SelectList(_context.ServiceType, "Id", "Name", partMaster.ServiceTypeId);
            return View(partMaster);
        }

        // POST: PartMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ServiceTypeId,Note,Price,MinPrice,MaxPrice,Quantity")] PartMaster partMaster)
        {
            if (id != partMaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartMasterExists(partMaster.Id))
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
            ViewData["ServiceTypeId"] = new SelectList(_context.ServiceType, "Id", "Name", partMaster.ServiceTypeId);
            return View(partMaster);
        }

        // GET: PartMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partMaster = await _context.PartMaster
                .Include(p => p.ServiceType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partMaster == null)
            {
                return NotFound();
            }

            return View(partMaster);
        }

        // POST: PartMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partMaster = await _context.PartMaster.FindAsync(id);
            _context.PartMaster.Remove(partMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartMasterExists(int id)
        {
            return _context.PartMaster.Any(e => e.Id == id);
        }
    }
}
