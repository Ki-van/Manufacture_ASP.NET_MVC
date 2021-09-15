using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KP_MANUFACTURE_MVC.Models
{
    public class Product_Raw
    {
        public int Id { get; set; }
        public int CostRate { get; set; }
        public int Lost { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int RawId { get; set; }
        public virtual Raw Raw { get; set; }
    }
}
