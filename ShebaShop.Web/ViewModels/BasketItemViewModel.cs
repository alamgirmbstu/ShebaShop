using ShebaShop.Web.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShebaShop.Web.ViewModels
{
    public class BasketItemViewModel
    {
        public int Id { get; set; }
        //public int CatalogItemId { get; set; }
        public string ProductName { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OldUnitPrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be bigger than 0")]
        public decimal Quantity { get; set; }

        public string PictureUrl { get; set; }

        public decimal SubTotal()
        {
            return Math.Round(UnitPrice * Quantity, 2);
        }
    }
}
