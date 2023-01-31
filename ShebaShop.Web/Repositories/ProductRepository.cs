using Microsoft.EntityFrameworkCore;
using ShebaShop.Web.Data;
using ShebaShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShebaShop.Web.Repositories
{
    public class ProductRepository:GenericRepository<Product>,IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<Product> GetAll()
        {
            return _context.Product.Include(a => a.Brand).Include(a => a.Type).ToList();

            //var q = (from pd in _context.Product
            //          join od in _context.tblOrders on pd.ProductID equals od.ProductID
            //         orderby od.OrderID
            //         select new
            //         {
            //             od.OrderID,
            //             pd.ProductID,
            //             pd.Name,
            //             pd.UnitPrice,
            //             od.Quantity,
            //             od.Price,
            //         }).ToList();
        }
    }
}
