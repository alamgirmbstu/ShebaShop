using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShebaShop.Web.Models
{
    public class Basket
    {
        public Guid Id { get; set; }
        public string BuyerId { get; private set; }
        public virtual List<BasketItem> BasketItems { get; set; }

        public int OrderState { get; set; }

    }
}
