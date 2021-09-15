using System;
using System.ComponentModel.DataAnnotations;

namespace KP_MANUFACTURE_MVC.Models
{
    public class Manufacture
    {
        public int Id { get; set; }
        [Display(Name = "План")]
        public uint Plan { get; set; }
        [Display(Name = "Заверешено")]
        public uint Complited { get; set; }
        [Display(Name = "Процент брака")]
        public uint Defect { get; set;}

       
        public int ProductId { get; set; }
        [Display(Name = "Наименование продукта")]
        public virtual Product Product { get; set; }
    }
}
