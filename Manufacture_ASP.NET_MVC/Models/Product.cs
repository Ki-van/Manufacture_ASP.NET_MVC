using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KP_MANUFACTURE_MVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Наименование продукта")]
        public string Name { get; set; }
        
        [Display(Name = "Себестоимость")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CostPrice { get; set; }

        [Display(Name = "Оптовая цена")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal WholesalePrice { get; set; }

        public virtual List<Manufacture> Manufactures { get; set; }
        public virtual List<Product_Raw> Product_Raws { get; set; }
    }
}
