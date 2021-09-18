using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Manufacture_ASP.NET_MVC.Models; 

namespace KP_MANUFACTURE_MVC.Models
{
    public class Export
    {
        public int Id { get; set; }
        [Display(Name = "Количество продукции в партии")]
        public int ProductCount { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Наименование продукта")]
        public virtual Product Product { get; set; }

        public int ImporterId { get; set; }
        [Display(Name = "ФИО импортера")]
        public virtual Importer Importer { get; set; }

        
        public string ComplitedStatusId { get; set; }
        
        [Display(Name = "Выполнено")]
        public virtual  ComplitedStatus ComplitedStatus { get; set; }

    }
}
