using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KP_MANUFACTURE_MVC.Models;
using Manufacture_ASP.NET_MVC.Data;

namespace Manufacture_ASP.NET_MVC.Controllers
{
    public class ManufactureController : Controller
    {
        private readonly ManufactureContext _context;

        public ManufactureController(ManufactureContext context)
        {
            _context = context;
        }

        // GET: Manufacture
        public async Task<IActionResult> Index()
        {
            var manufactureContext = _context.Manufacture.Include(m => m.Product);
            return View(await manufactureContext.ToListAsync());
        }

        // GET: Manufacture/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacture = await _context.Manufacture
                .Include(m => m.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manufacture == null)
            {
                return NotFound();
            }

            return View(manufacture);
        }

        // GET: Manufacture/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
            return View();
        }

        // POST: Manufacture/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Plan,Complited,Defect,ProductId")] Manufacture manufacture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manufacture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", manufacture.ProductId);
            return View(manufacture);
        }

        // GET: Manufacture/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacture = await _context.Manufacture.FindAsync(id);
            if (manufacture == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", manufacture.ProductId);
            return View(manufacture);
        }

        // POST: Manufacture/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Plan,Complited,Defect,ProductId")] Manufacture manufacture)
        {
            if (id != manufacture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manufacture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManufactureExists(manufacture.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", manufacture.ProductId);
            return View(manufacture);
        }

        // GET: Manufacture/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacture = await _context.Manufacture
                .Include(m => m.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manufacture == null)
            {
                return NotFound();
            }

            return View(manufacture);
        }

        // POST: Manufacture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manufacture = await _context.Manufacture.FindAsync(id);
            _context.Manufacture.Remove(manufacture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManufactureExists(int id)
        {
            return _context.Manufacture.Any(e => e.Id == id);
        }
    }
}
