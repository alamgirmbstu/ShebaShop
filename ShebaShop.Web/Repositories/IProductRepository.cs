using ShebaShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShebaShop.Web.Repositories
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        IEnumerable<Product> GetAll();
    }
}
