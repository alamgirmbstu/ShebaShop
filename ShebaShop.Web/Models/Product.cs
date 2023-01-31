using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShebaShop.Web.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        [DefaultValue(0)]
        public decimal UnitPrice { get; set; }
        public string Unit { get; set; }
        [DefaultValue(0)]
        public int Stock { get; set; }

        public string PhotoPath { get; set; }

        [ForeignKey("Type")]
        public int ProductTypeId { get; set; }
        [ForeignKey("Brand")]
        public int ProductBrandId { get; set; }

        public ProductType Type { get; set; }
        public ProductBrand Brand { get; set; }

    }
}
