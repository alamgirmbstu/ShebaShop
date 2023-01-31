using Microsoft.EntityFrameworkCore;
using ShebaShop.Web.Data;
using ShebaShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShebaShop.Web.Repositories
{
    public class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        ApplicationDbContext _context;
        public BasketRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Basket GetBasketByBuyerId(string buyerName, int OrderState = 0)
        {
            throw new NotImplementedException();

            //return _context.Baskets.Where(b => b.BuyerId == buyerName).Where(b=>b.OrderState == OrderState).Include(a => a.BasketItems).FirstOrDefault();
        }
    }
}
