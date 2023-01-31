using ShebaShop.Web.Data;
using ShebaShop.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShebaShop.Web.UOW
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ProductBrandRepo = new ProductBrandRepository(_context);
            ProductTypeRepo = new ProductTypeRepository(_context);
            ProductRepo = new ProductRepository(_context);
        }

        public IProductBrandRepository ProductBrandRepo { get; private set; }
        public IProductTypeRepository ProductTypeRepo { get; private set; }
        public IProductRepository ProductRepo { get; private set; }

        public int Complete()
        {            
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
