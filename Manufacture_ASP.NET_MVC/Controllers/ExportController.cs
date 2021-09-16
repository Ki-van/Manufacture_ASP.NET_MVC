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
    public class ExportController : Controller
    {
        private readonly ManufactureContext _context;

        public ExportController(ManufactureContext context)
        {
            _context = context;
        }

        // GET: Export
        public async Task<IActionResult> Index()
        {
            var manufactureContext = _context.Export.Include(e => e.Importer).Include(e => e.Product);
            return View(await manufactureContext.ToListAsync());
        }

        // GET: Export/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var export = await _context.Export
                .Include(e => e.Importer)
                .Include(e => e.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (export == null)
            {
                return NotFound();
            }

            return View(export);
        }

        // GET: Export/Create
        public IActionResult Create()
        {
            ViewData["ImporterId"] = new SelectList(_context.Importer, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
            return View();
        }

        // POST: Export/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductCount,FullName,Country,ProductId,ImporterId")] Export export)
        {
            if (ModelState.IsValid)
            {
                _context.Add(export);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ImporterId"] = new SelectList(_context.Importer, "Id", "Id", export.ImporterId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", export.ProductId);
            return View(export);
        }

        // GET: Export/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var export = await _context.Export.FindAsync(id);
            if (export == null)
            {
                return NotFound();
            }
            ViewData["ImporterId"] = new SelectList(_context.Importer, "Id", "Id", export.ImporterId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", export.ProductId);
            return View(export);
        }

        // POST: Export/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductCount,FullName,Country,ProductId,ImporterId")] Export export)
        {
            if (id != export.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(export);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExportExists(export.Id))
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
            ViewData["ImporterId"] = new SelectList(_context.Importer, "Id", "Id", export.ImporterId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", export.ProductId);
            return View(export);
        }

        // GET: Export/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var export = await _context.Export
                .Include(e => e.Importer)
                .Include(e => e.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (export == null)
            {
                return NotFound();
            }

            return View(export);
        }

        // POST: Export/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var export = await _context.Export.FindAsync(id);
            _context.Export.Remove(export);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExportExists(int id)
        {
            return _context.Export.Any(e => e.Id == id);
        }
    }
}
