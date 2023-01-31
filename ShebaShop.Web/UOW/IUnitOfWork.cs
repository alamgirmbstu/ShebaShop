using ShebaShop.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShebaShop.Web.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IProductBrandRepository ProductBrandRepo { get; }
        IProductTypeRepository ProductTypeRepo { get; }
        IProductRepository ProductRepo { get; }
        int Complete();
    }
}
