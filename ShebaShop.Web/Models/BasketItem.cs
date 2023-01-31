using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShebaShop.Web.Models
{
    public class BasketItem
    {
        public Guid Id { get; set; }

        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        //public int CatalogItemId { get; private set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public int BasketId { get; private set; }

    }
}
