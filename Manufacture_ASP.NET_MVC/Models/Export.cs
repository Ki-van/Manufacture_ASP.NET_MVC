using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KP_MANUFACTURE_MVC.Models
{
    public class Export
    {
        public int Id { get; set; }
        [Display(Name = "Количество продукции в партии")]
        public int ProductCount { get; set; }
        public string FullName { get; set; }
        [Display(Name = "Страна импортера")]
        public string Country { get; set; }

        public int ProductId { get; set; }
        [Display(Name = "Наименование продукта")]
        public virtual Product Product { get; set; }

        public int ImporterId { get; set; }
        [Display(Name = "ФИО импортера")]
        public virtual Importer Importer { get; set; }
    }
}
