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
        private readonly CollectionLogic _collectionLogic;
        public HomeController()
        {
            _productLogic = new ProductLogic();
        }

        public ActionResult Index()
        {
            var productos = _productLogic.GetAllActives();
            var viewModel = new UserHomeView
            {
                AllProducts = productos
            };
            return View(viewModel);
        }

        public ActionResult Collections()
        {
            var collections = _collectionLogic.GetAllActives();
            var viewModel = new UserHomeView
            {
                AllCollections = collections
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