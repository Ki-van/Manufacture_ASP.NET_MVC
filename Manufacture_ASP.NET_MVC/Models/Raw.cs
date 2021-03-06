using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KP_MANUFACTURE_MVC.Models
{
    public class Raw
    {
        public int Id { get; set; }
        [Display(Name = "Наименование сырья")]
        public string Name { get; set; }

        public virtual List<Product_Raw> Product_Raws { get; set; }
    }
}
