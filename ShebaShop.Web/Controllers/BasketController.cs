using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShebaShop.Web.Services;
using ShebaShop.Web.UOW;
using ShebaShop.Web.ViewModels;

namespace ShebaShop.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _user;
        public BasketController(IUnitOfWork unitOfWork, UserManager<IdentityUser> user, SignInManager<IdentityUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _user = user;
            _signInManager = signInManager;

            // SessionExtension.CurrentUserName = _user.GetUserName(this.User);
        }
        public IActionResult Index(int pid)
        {
            // var basketVM = SessionExtension.GetBASKET<BasketViewModel>(HttpContext.Session);

            var product = _unitOfWork.ProductRepo.GetById(pid);

            return View(product);
        }

        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult AddToCart(int pid, decimal qty)
        {
            if (pid == 0 || qty == 0)
            {
              return  RedirectToAction("Index", "Home");
            }
            var basket = SessionExtension.GetBASKET(HttpContext.Session);

            if (basket == null)
            {
                basket = new BasketViewModel();
            }
            bool itemFound = false;

            if (basket.Items != null)
            {
                foreach (BasketItemViewModel item in basket.Items)
                {
                    if (item.Product.Id == pid)
                    {
                        itemFound = true;
                        item.Quantity = qty;
                        break;
                    }
                }
            }

            var product = _unitOfWork.ProductRepo.GetById(pid);
            if (!itemFound)
            {
                basket.Items.Add(new BasketItemViewModel
                {
                    Quantity = qty,
                    ProductName = product.ProductName,
                    Product = product,
                    UnitPrice = product.UnitPrice,
                    OldUnitPrice = product.UnitPrice,
                });
            }

            SessionExtension.UpdateBasket(HttpContext.Session, basket);


            return RedirectToAction("Index", "Home");
        }

        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult CheckoutCart()
        {
            var basket = SessionExtension.GetBASKET(HttpContext.Session);

            if (basket == null)
            {
                ViewData["CartMsg"] = "No item found";
                return View(default(BasketViewModel));
            }

            return View(basket);
        }

        //public IActionResult OrderPlace()
        //{
        //    var basket = SessionExtension.GetBASKET(HttpContext.Session);

        //    if (basket == null)
        //    {
        //        ViewData["CartMsg"] = "No item found";
        //        return View(default(BasketViewModel));
        //    }

        //    return View(basket);
        //}
    }
}
