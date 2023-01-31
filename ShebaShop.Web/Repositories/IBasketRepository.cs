using ShebaShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShebaShop.Web.Repositories
{
    public interface IBasketRepository : IGenericRepository<Basket>
    {
        Basket GetBasketByBuyerId(string buyerName, int State = 0);
    }
}
