using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_MVC.Models;

namespace UI_MVC.Controllers
{    public class CollectionsController : Controller
    {
        private readonly CollectionLogic _collectionLogic;

        public CollectionsController()
        {
            _collectionLogic = new CollectionLogic();
        }

        public ActionResult Index()
        {
            var collections = _collectionLogic.GetAllActives();
            var viewModel = new UserHomeView
            {
                AllCollections = collections
            };
            return View(viewModel);
        }
    }

}