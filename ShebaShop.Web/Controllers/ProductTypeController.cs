using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ShebaShop.Web.Models;
using ShebaShop.Web.UOW;

namespace ShebaShop.Web.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public IActionResult Index()
        {
            var productType = _unitOfWork.ProductTypeRepo.GetAll().ToList();
            return View(productType);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductType Type)
        {
            _unitOfWork.ProductTypeRepo.Add(Type);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {            
            return View(_unitOfWork.ProductTypeRepo.GetById(Id));
        }

        [HttpPost]
        public IActionResult Edit(ProductType PT)
        {
            if (ModelState.IsValid)
            {
                var item = _unitOfWork.ProductTypeRepo.GetById(PT.Id);
                item.ProductTypeName = PT.ProductTypeName;
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
