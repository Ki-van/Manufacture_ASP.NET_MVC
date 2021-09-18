using Manufacture_ASP.NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Manufacture_ASP.NET_MVC.Data;
using KP_MANUFACTURE_MVC.Models;

namespace Manufacture_ASP.NET_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ManufactureContext _context;
        public HomeController(ManufactureContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sclad = new Dictionary<string, long>();
            foreach(var product in _context.Product)
            {
                
                long productProduced = _context.Manufacture.Where(m => m.ProductId == product.Id)
                    .Select((manf) =>
                         (long)((decimal)manf.Complited - (decimal)manf.Complited * ((decimal)manf.Defect / 100)))
                    .Sum();
                
                long productExported = _context.Export.Where(e => e.ProductId == product.Id && e.ComplitedStatusId == "Да")
                    .Select((exp) => (long)exp.ProductCount)
                    .Sum();
                
                sclad.Add(product.Name, productProduced - productExported);
            }

            var BestCustomers = new Dictionary<Importer, long>();
            foreach(var importer in _context.Importer)
            {
                BestCustomers.Add(importer, 0);
                foreach(var export in _context.Export.Where(exp => exp.ImporterId == importer.Id))
                {
                    if (export.ProductCount > 100)
                        BestCustomers[importer] += (long) (export.ProductCount * _context.Product.Find(export.ProductId).WholesalePrice);
                    else
                        BestCustomers[importer] += (long)(export.ProductCount * _context.Product.Find(export.ProductId).CostPrice);
                }
            }
            var list = BestCustomers.ToList();
            list.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            ViewBag.BestCustomers = list;

            var LackOfProduct = new Dictionary<Product, Int64>();
            foreach (var product in _context.Product)
            {

                long productProduced = _context.Manufacture.Where(m => m.ProductId == product.Id)
                    .Select((manf) =>
                         (long)((decimal)manf.Complited - (decimal)manf.Complited * ((decimal)manf.Defect / 100)))
                    .Sum();

                long productExported = _context.Export.Where(e => e.ProductId == product.Id)
                    .Select((exp) => (long)exp.ProductCount)
                    .Sum();

                LackOfProduct.Add(product, (Int64)productExported - (Int64)productProduced);
            }

            ViewBag.LackOfProduct = LackOfProduct;

            return View(sclad);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
