using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KP_MANUFACTURE_MVC.Models;
using Manufacture_ASP.NET_MVC.Data;
using Manufacture_ASP.NET_MVC.Controllers;

namespace KP_MANUFACTURE_MVC.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Наименование продукта")]
        public string Name { get; set; }

        [Display(Name = "Себестоимость")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal CostPrice { get; set; }

        [Display(Name = "Оптовая цена")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal WholesalePrice { get; set; }

        public virtual List<Manufacture> Manufactures { get; set; }
        public virtual List<Product_Raw> Product_Raws { get; set; }
        public virtual List<Export> Exports { get; set; }
    }
}
