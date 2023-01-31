using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using ShebaShop.Web.Models;
using ShebaShop.Web.UOW;
using ShebaShop.Web.ViewModels;

namespace ShebaShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IHostingEnvironment _hostingEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            var _products = _unitOfWork.ProductRepo.GetAll();

            return View(_products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewData["Brand"] = _unitOfWork.ProductBrandRepo.GetAll();
            ViewData["Type"] = _unitOfWork.ProductTypeRepo.GetAll();

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductVM product)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var uploadsPath = Path.Combine(_hostingEnvironment.WebRootPath, "PostImages");
                    var img = product.PhotoPath;
                   

                    //Getting file meta data
                    var filePath = string.Empty;
                    var fileName = string.Empty;

                    if (product.PhotoPath != null && product.PhotoPath.Length > 0)
                    {
                        fileName = Path.GetFileName(product.PhotoPath.FileName);
                        var contentType = product.PhotoPath.ContentType;
                        filePath = Path.Combine(uploadsPath, fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            product.PhotoPath.CopyTo(fileStream);
                        }
                    }

                    var NewProduct = new Product
                    {
                        ProductName = product.ProductName,
                        ProductBrandId = product.ProductBrandId,
                        ProductTypeId = product.ProductTypeId,
                        UnitPrice = product.UnitPrice,
                        Stock = product.Stock,
                        Unit = product.Unit,
                        PhotoPath = fileName,
                    };


                    _unitOfWork.ProductRepo.Add(NewProduct);
                    _unitOfWork.Complete();

                    TempData["SUCC_MSG"] = "Save Successful";
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _unitOfWork.ProductRepo.GetById(id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection form)
        {
            try
            {
                var product = _unitOfWork.ProductRepo.GetById(id);

                if (product != null)
                {
                    product.ProductName= Convert.ToString(form["ProductName"]);
                    product.UnitPrice = Convert.ToDecimal(form["UnitPrice"]);
                    product.Unit = Convert.ToString(form["Unit"]);
                    product.Stock = Convert.ToInt32(form["Stock"]);

                    _unitOfWork.Complete();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
