using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
namespace KP_MANUFACTURE_MVC.Models
{
    public class Product_Raw
    {
        public int Id { get; set; }

        [Display(Name = "Норма затрат")]
        public int CostRate { get; set; }

        [Display(Name = "Потери")]
        public int Lost { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Продукт")]
        public virtual Product Product { get; set; }
        public int RawId { get; set; }
        [Display(Name = "Сырье")]
        public virtual Raw Raw { get; set; }
    }
}
