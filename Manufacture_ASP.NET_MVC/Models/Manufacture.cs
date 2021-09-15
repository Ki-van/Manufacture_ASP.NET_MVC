using System;
using System.ComponentModel.DataAnnotations;

namespace KP_MANUFACTURE_MVC.Models
{
    public class Manufacture
    {
        public int Id { get; set; }
        public uint Plan { get; set; }
        public uint Complited { get; set; }
        public uint Defect { get; set;}


        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
