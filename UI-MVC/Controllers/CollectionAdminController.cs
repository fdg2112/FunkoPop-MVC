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
    public class CollectionAdminController : Controller
    {
        readonly CollectionLogic collectionLogic = new CollectionLogic();

        // GET: Collection
        public ActionResult Index()
        {
            List<Collection> collections = collectionLogic.GetAll();
            List<CollectionsView> collectionsView = collections.Select(s => new CollectionsView
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Ref_image = s.Ref_image,
                Url_image = s.Url_image
            }).ToList();

            return View(collectionsView);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CollectionsView collectionsView)
        {
            try
            {
                Collection collectionEntity = new Collection
                {
                    Name = collectionsView.Name,
                    Description = collectionsView.Description,
                    Url_image = collectionsView.Url_image,
                    Ref_image = collectionsView.Ref_image,
                    Active = true
                };
                collectionLogic.Add(collectionEntity);
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
                collectionLogic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Edit(int id, CollectionsView collectionsView)
        {
            try
            {
                Collection collectionEntity = new Collection
                {
                    Name = collectionsView.Name,
                    Description = collectionsView.Description,
                    Url_image = collectionsView.Url_image,
                    Ref_image = collectionsView.Ref_image
                };
                collectionLogic.Update(collectionEntity);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}