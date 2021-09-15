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
    }
}
