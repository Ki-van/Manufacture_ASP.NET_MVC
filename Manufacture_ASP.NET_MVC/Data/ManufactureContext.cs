using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KP_MANUFACTURE_MVC.Models;

namespace Manufacture_ASP.NET_MVC.Data
{
    public class ManufactureContext : DbContext
    {
        public ManufactureContext (DbContextOptions<ManufactureContext> options)
            : base(options)
        {
        }

        public DbSet<KP_MANUFACTURE_MVC.Models.Product> Product { get; set; }

        public DbSet<KP_MANUFACTURE_MVC.Models.Manufacture> Manufacture { get; set; }

        public DbSet<KP_MANUFACTURE_MVC.Models.Raw> Raw { get; set; }

        public DbSet<KP_MANUFACTURE_MVC.Models.Product_Raw> Product_Raw { get; set; }

        public DbSet<KP_MANUFACTURE_MVC.Models.Importer> Importer { get; set; }

        public DbSet<KP_MANUFACTURE_MVC.Models.Export> Export { get; set; }
    }
}
