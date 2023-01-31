using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShebaShop.Web.Models;
using ShebaShop.Web.ViewModels;

namespace ShebaShop.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ShebaShop.Web.Models.ProductBrand> ProductBrands { get; set; }
        public DbSet<ShebaShop.Web.Models.ProductType> ProductTypes { get; set; }
        public DbSet<ShebaShop.Web.Models.Product> Product { get; set; }
        //public DbSet<ShebaShop.Web.ViewModels.BasketViewModel> BasketViewModel { get; set; }
        //public DbSet<Basket> Baskets { get; set; }
    }
}
