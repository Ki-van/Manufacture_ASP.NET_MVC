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
    public class Product_RawController : Controller
    {
        private readonly ManufactureContext _context;

        public Product_RawController(ManufactureContext context)
        {
            _context = context;
        }

        // GET: Product_Raw
        public async Task<IActionResult> Index()
        {
            var manufactureContext = _context.Product_Raw.Include(p => p.Product).Include(p => p.Raw);
            return View(await manufactureContext.ToListAsync());
        }

        // GET: Product_Raw/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Raw = await _context.Product_Raw
                .Include(p => p.Product)
                .Include(p => p.Raw)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product_Raw == null)
            {
                return NotFound();
            }

            return View(product_Raw);
        }

        // GET: Product_Raw/Create
        public IActionResult Create()
        {
            ViewData["ProductName"] = new SelectList(_context.Product, "Name", "Name");
            ViewData["RawName"] = new SelectList(_context.Raw, "Name", "Name");
            return View();
        }

        // POST: Product_Raw/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more Details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CostRate,Lost")] Product_Raw product_Raw, string Product, string Raw)
        {
            Product product = _context.Product.Where(p => p.Name == Product).First();
            Raw raw = _context.Raw.Where(p => p.Name == Raw).First();
            product_Raw.ProductId = product.Id;
            product_Raw.RawId = raw.Id;

            if (ModelState.IsValid)
            {
                _context.Add(product_Raw);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductName"] = new SelectList(_context.Product, "Name", "Name", product.Name);
            ViewData["RawName"] = new SelectList(_context.Raw, "Name", "Name", raw.Name);
            return View(product_Raw);
        }

        // GET: Product_Raw/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Raw = await _context.Product_Raw.FindAsync(id);
            if (product_Raw == null)
            {
                return NotFound();
            }

            ViewData["ProductName"] = new SelectList(_context.Product, "Name", "Name", _context.Product.Find(product_Raw.ProductId).Name);
            ViewData["RawName"] = new SelectList(_context.Raw, "Name", "Name", _context.Raw.Find(product_Raw.RawId).Name);
            return View(product_Raw);
        }

        // POST: Product_Raw/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more Details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CostRate,Lost")] Product_Raw product_Raw, string Product, string Raw)
        {
            Product product = _context.Product.Where(p => p.Name == Product).First();
            Raw raw = _context.Raw.Where(p => p.Name == Raw).First();
            product_Raw.ProductId = product.Id;
            product_Raw.RawId = raw.Id;

            if (id != product_Raw.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product_Raw);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Product_RawExists(product_Raw.Id))
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
            ViewData["ProductName"] = new SelectList(_context.Product, "Name", "Name", product.Name);
            ViewData["RawName"] = new SelectList(_context.Raw, "Name", "Name", raw.Name);
            return View(product_Raw);
        }

        // GET: Product_Raw/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Raw = await _context.Product_Raw
                .Include(p => p.Product)
                .Include(p => p.Raw)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product_Raw == null)
            {
                return NotFound();
            }

            return View(product_Raw);
        }

        // POST: Product_Raw/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product_Raw = await _context.Product_Raw.FindAsync(id);
            _context.Product_Raw.Remove(product_Raw);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Product_RawExists(int id)
        {
            return _context.Product_Raw.Any(e => e.Id == id);
        }
    }
}
