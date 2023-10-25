using Entities;
using Logic;
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
            _collectionLogic = new CollectionLogic();
        }

        public ActionResult Index()
        {
            var products = _productLogic.GetAllActives();
            var viewModel = new UserHomeView
            {
                AllProducts = products
            };
            return View(viewModel);
        }

        public ActionResult ProductDetail(int id)
        {
            Product product = _productLogic.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var productView = new ProductView
            {
                Id = product.Id,
                Catalog_number = product.Catalog_number,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Shine = product.Shine,
                Url_image = product.Url_image,
                Ref_image = product.Ref_image
            };

            return View(productView);
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