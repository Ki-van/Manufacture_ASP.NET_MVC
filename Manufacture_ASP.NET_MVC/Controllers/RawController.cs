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
    public class RawController : Controller
    {
        private readonly ManufactureContext _context;

        public RawController(ManufactureContext context)
        {
            _context = context;
        }

        // GET: Raw
        public async Task<IActionResult> Index()
        {
            return View(await _context.Raw.ToListAsync());
        }

        // GET: Raw/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raw = await _context.Raw
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raw == null)
            {
                return NotFound();
            }

            return View(raw);
        }

        // GET: Raw/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Raw/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Raw raw)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raw);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raw);
        }

        // GET: Raw/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raw = await _context.Raw.FindAsync(id);
            if (raw == null)
            {
                return NotFound();
            }
            return View(raw);
        }

        // POST: Raw/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Raw raw)
        {
            if (id != raw.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raw);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RawExists(raw.Id))
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
            return View(raw);
        }

        // GET: Raw/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raw = await _context.Raw
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raw == null)
            {
                return NotFound();
            }

            return View(raw);
        }

        // POST: Raw/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raw = await _context.Raw.FindAsync(id);
            _context.Raw.Remove(raw);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RawExists(int id)
        {
            return _context.Raw.Any(e => e.Id == id);
        }
    }
}
