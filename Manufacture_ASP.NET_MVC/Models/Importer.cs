using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KP_MANUFACTURE_MVC.Models
{
    public class Importer
    {
        public int Id { get; set; }
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        [Display(Name = "Страна импортера")]
        public string Country { get; set; }

        public virtual List<Export> Exports { get; set; }
    }
}
