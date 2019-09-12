using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.WebMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var service = new CategoryService();
            var model = service.GetCategories();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST : Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCategoryService();

            if (service.CreateCategory(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            return View(model);
        }

        // GET : Edit
        public ActionResult Edit(int id)
        {
            var service = CreateCategoryService();
            var detail = service.GetCategoryByID(id);
            var model =
                new CategoryListItem
                {
                    CategoryID = detail.CategoryID,
                    CategoryName = detail.CategoryName
                };
            return View(model);
        }

        // POST : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryListItem model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CategoryID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
            }

            var service = CreateCategoryService();

            if (service.UpdateCategory(model))
            {
                TempData["SaveResult"] = "Your category was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your category could not be updated.");
            return View(model);
        }

        // GET : Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCategoryService();
            var model = svc.GetCategoryByID(id);

            return View(model);
        }

        // POST : Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCategoryService();

            service.DeleteCategory(id);

            TempData["SaveResult"] = "Your category was deleted";

            return RedirectToAction("Index");
        }


        private CategoryService CreateCategoryService()
        {
            var service = new CategoryService();
            return service;
        }
    }
}