using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manufacture_ASP.NET_MVC.Data;
using Manufacture_ASP.NET_MVC.Models;

namespace Manufacture_ASP.NET_MVC.Controllers
{
    public class ComplitedStatusController : Controller
    {
        private readonly ManufactureContext _context;

        public ComplitedStatusController(ManufactureContext context)
        {
            _context = context;
        }

        // GET: ComplitedStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ComplitedStatus.ToListAsync());
        }

        // GET: ComplitedStatus/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complitedStatus = await _context.ComplitedStatus
                .FirstOrDefaultAsync(m => m.Status == id);
            if (complitedStatus == null)
            {
                return NotFound();
            }

            return View(complitedStatus);
        }

        // GET: ComplitedStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ComplitedStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Status")] ComplitedStatus complitedStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(complitedStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(complitedStatus);
        }

        // GET: ComplitedStatus/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complitedStatus = await _context.ComplitedStatus.FindAsync(id);
            if (complitedStatus == null)
            {
                return NotFound();
            }
            return View(complitedStatus);
        }

        // POST: ComplitedStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Status")] ComplitedStatus complitedStatus)
        {
            if (id != complitedStatus.Status)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(complitedStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComplitedStatusExists(complitedStatus.Status))
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
            return View(complitedStatus);
        }

        // GET: ComplitedStatus/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complitedStatus = await _context.ComplitedStatus
                .FirstOrDefaultAsync(m => m.Status == id);
            if (complitedStatus == null)
            {
                return NotFound();
            }

            return View(complitedStatus);
        }

        // POST: ComplitedStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var complitedStatus = await _context.ComplitedStatus.FindAsync(id);
            _context.ComplitedStatus.Remove(complitedStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComplitedStatusExists(string id)
        {
            return _context.ComplitedStatus.Any(e => e.Status == id);
        }
    }
}
