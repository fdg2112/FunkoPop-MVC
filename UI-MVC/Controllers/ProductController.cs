using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_MVC.Models;

namespace UI_MVC.Controllers
{
    public class ProductController : Controller
    {
        readonly ProductLogic productLogic = new ProductLogic();

        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = productLogic.GetAll();
            List<ProductView> productsView = products.Select(s => new ProductView
            {
                Id = s.Id,
                Catalog_number = s.Catalog_number,
                Name = s.Name,
                Description = s.Description,
                Price = s.Price,
                Stock = s.Stock,
                Shine = s.Shine
            }).ToList();

            return View(productsView);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(ProductView productView)
        {
            try
            {
                Product productEntity = new Product
                {
                    Catalog_number = productView.Catalog_number,
                    Name = productView.Name,
                    Description = productView.Description,
                    Price = productView.Price,
                    Stock = productView.Stock,
                    Shine = productView.Shine
                };
                productLogic.Add(productEntity);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                productLogic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Edit(int id, ProductView productView)
        {
            try
            {
                Product productEntity = new Product
                {
                    Id = id,
                    Catalog_number = productView.Catalog_number,
                    Name = productView.Name,
                    Description = productView.Description,
                    Price = productView.Price,
                    Stock = productView.Stock,
                    Shine = productView.Shine
                };
                productLogic.Update(productEntity);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}