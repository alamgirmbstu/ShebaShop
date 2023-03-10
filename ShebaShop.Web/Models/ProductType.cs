using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShebaShop.Web.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        [StringLength(40)]
        public string ProductTypeName { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
