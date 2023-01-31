using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShebaShop.Web.Models;
using ShebaShop.Web.UOW;

namespace ShebaShop.Web.Controllers
{
    public class ProductBrandController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductBrandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public IActionResult Index()
        {
            var brand = _unitOfWork.ProductBrandRepo.GetAll().ToList();
            return View(brand);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductBrand brand)
        {
            _unitOfWork.ProductBrandRepo.Add(brand);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            return View(_unitOfWork.ProductBrandRepo.GetById(Id));
        }

        [HttpPost]
        public IActionResult Edit(ProductBrand PT)
        {
            return View();
        }
    }
}
