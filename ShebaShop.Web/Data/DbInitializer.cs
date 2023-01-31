using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using ShebaShop.Web.Models;
using System;
using System.Linq;

namespace ShebaShop.Web.Data
{
    public class DbInitializer
    {

        //public static void Initialize1(IServiceProvider serviceProvider)
        //{
        //    using (var context = new ApplicationDbContext(
        //        serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        //    {
        //        if (context.ProductTypes.Any())
        //        {
        //            return;

        //        }

        //    }
        //}
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {

                string _adminUserName = "admin@admin.com";
                string _adminPassword = "Leads@123";

                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                var _userManager =
                         serviceScope.ServiceProvider.GetService<UserManager<IdentityUser>>();
                var _roleManager =
                         serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                if (!context.Users.Any(usr => usr.UserName == _adminUserName))
                {
                    var user = new IdentityUser()
                    {
                        UserName = _adminUserName,
                        Email = _adminUserName,
                        EmailConfirmed = true,
                    };

                    var userResult = _userManager.CreateAsync(user, _adminPassword).Result;
                }

                if (!_roleManager.RoleExistsAsync("Admin").Result)
                {
                    var role = _roleManager.CreateAsync
                               (new IdentityRole { Name = "Admin" }).Result;
                }

                if (!_roleManager.RoleExistsAsync("User").Result)
                {
                    var role = _roleManager.CreateAsync
                               (new IdentityRole { Name = "User" }).Result;
                }

                var adminUser = _userManager.FindByNameAsync(_adminUserName).Result;
                var userRole = _userManager.AddToRolesAsync
                               (adminUser, new string[] { "Admin" }).Result;


                //var terminal = context.Terminal
                //                  .Where(x => x.Name == "Test").FirstOrDefault();

                //if (terminal == null)
                //{
                //    terminal = new Terminal()
                //    {
                //        Name = "Test",
                //        CreatedDate = DateTime.Now,
                //    };

                //    context.Terminal.Add(terminal);
                //}

                //Product Type
                //ProductType pt = new Models.ProductType { ProductTypeName = "Mouse" };
                //context.ProductTypes.Add(pt);
                //pt = new Models.ProductType { ProductTypeName = "Keyboard" };
                //context.ProductTypes.Add(pt);
                //pt = new Models.ProductType { ProductTypeName = "Headphone" };
                //context.ProductTypes.Add(pt);
                //pt = new Models.ProductType { ProductTypeName = "Laptop" };
                //context.ProductTypes.Add(pt);

                //// Product Brand
                //ProductBrand pb = new ProductBrand { BrandName = "ASUS" };
                //context.ProductBrands.Add(pb);
                //pb = new ProductBrand { BrandName = "DELL" };
                //context.ProductBrands.Add(pb);
                //pb = new ProductBrand { BrandName = "HP" };
                //context.ProductBrands.Add(pb);     

                if (!context.ProductTypes.Any())
                {
                    ProductType pt = new Models.ProductType { ProductTypeName = "Shirt" };
                    context.ProductTypes.Add(pt);
                    pt = new Models.ProductType { ProductTypeName = "Pant" };
                    context.ProductTypes.Add(pt);
                }

                if (!context.ProductBrands.Any())
                {
                    ProductBrand pb = new ProductBrand { BrandName = "YELLOW" };
                    context.ProductBrands.Add(pb);
                    pb = new ProductBrand { BrandName = "O-Code" };
                    context.ProductBrands.Add(pb);
                    pb = new ProductBrand { BrandName = "Pretex" };
                    context.ProductBrands.Add(pb);
                    pb = new ProductBrand { BrandName = "Infinity" };
                    context.ProductBrands.Add(pb);
                }

                context.SaveChanges();

                if (!context.Product.Any())
                {
                    var ptShirt = context.ProductTypes.Where(pt => pt.ProductTypeName == "Shirt").FirstOrDefault();
                    var ptPant = context.ProductTypes.Where(pt => pt.ProductTypeName == "Pant").FirstOrDefault();

                    var pb1 = context.ProductBrands.Where(pt => pt.BrandName == "YELLOW").FirstOrDefault();


                    context.Product.AddRange(
                        new Product { ProductName="Men's Shirt", PhotoPath = "Shirt.jpg", Stock = 100, Unit = "Pcs", UnitPrice = 1500, Brand = pb1, Type = ptShirt },
                        new Product { ProductName="Men's Pant", PhotoPath = "pant.jpg", Stock = 100, Unit = "Pcs", UnitPrice = 1500, Brand = pb1, Type = ptPant }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}
