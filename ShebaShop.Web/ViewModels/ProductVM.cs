using Microsoft.AspNetCore.Http;

namespace ShebaShop.Web.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string Unit { get; set; }
        public int Stock { get; set; }

        public IFormFile PhotoPath { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }
    }
}
