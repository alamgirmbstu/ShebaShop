using ShebaShop.Web.Data;
using ShebaShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShebaShop.Web.Repositories
{
    public class BasketItemRepository : GenericRepository<BasketItem>, IBasketItemRepository
    {
        public BasketItemRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
