using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_MVC.Models;

namespace UI_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductLogic _productLogic;
        public HomeController()
        {
            _productLogic = new ProductLogic();
        }
        //public ActionResult Index()
        //{
        //    var productsAZ = _productLogic.GetAll().OrderBy(p => p.Name);
        //    var productsZA = _productLogic.GetAll().OrderByDescending(p => p.Name);
        //    var productsByPriceAsc = _productLogic.GetAll().OrderBy(p => p.Price);
        //    var productsByPriceDesc = _productLogic.GetAll().OrderByDescending(p => p.Price);
        //    var productsShine = _productLogic.GetAll().Where(p => p.Shine = true);
        //    var viewModel = new UserHomeView
        //    {
        //        ProductsAZ = productsAZ,
        //        ProductsZA = productsZA,
        //        ProductsByPriceAsc = productsByPriceAsc,
        //        ProductsByPriceDesc = productsByPriceDesc,
        //        ProductsShine = productsShine
        //    };
        //    return View(viewModel);
        //}

        public ActionResult Index()
        {
            var unProducto = _productLogic.GetOne();
            var viewModel = new UserHomeView
            {
                OneProduct = unProducto
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}