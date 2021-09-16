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
    public class ImporterController : Controller
    {
        private readonly ManufactureContext _context;

        public ImporterController(ManufactureContext context)
        {
            _context = context;
        }

        // GET: Importer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Importer.ToListAsync());
        }

        // GET: Importer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importer = await _context.Importer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (importer == null)
            {
                return NotFound();
            }

            return View(importer);
        }

        // GET: Importer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Importer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Country")] Importer importer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(importer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(importer);
        }

        // GET: Importer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importer = await _context.Importer.FindAsync(id);
            if (importer == null)
            {
                return NotFound();
            }
            return View(importer);
        }

        // POST: Importer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Country")] Importer importer)
        {
            if (id != importer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(importer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImporterExists(importer.Id))
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
            return View(importer);
        }

        // GET: Importer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importer = await _context.Importer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (importer == null)
            {
                return NotFound();
            }

            return View(importer);
        }

        // POST: Importer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var importer = await _context.Importer.FindAsync(id);
            _context.Importer.Remove(importer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImporterExists(int id)
        {
            return _context.Importer.Any(e => e.Id == id);
        }
    }
}
