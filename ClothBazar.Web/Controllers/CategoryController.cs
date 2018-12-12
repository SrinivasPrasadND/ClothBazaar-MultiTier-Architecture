using ClothBazar.Entities;
using ClothBazar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoriesService categoryService = new CategoriesService();
        // GET: Category

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryTable(string search)
        {
            var categories = categoryService.GetCategories();

            if (!string.IsNullOrEmpty(search))
            {
                categories = categories.Where(c => c.Name != null && c.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            return PartialView(categories);
        }

        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryService.SaveCategory(category);
            return RedirectToAction("CategoryTable");
        }

        public ActionResult Edit(int ID)
        {
            var cat = categoryService.GetCategory(ID);
            return PartialView(cat);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            categoryService.UpdateCategory(category);
            return RedirectToAction("CategoryTable");
        }

        //public ActionResult Delete(int ID)
        //{
        //    var cat = categoryService.GetCategory(ID);
        //    return PartialView(cat);
        //}

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            categoryService.DeleteCategory(ID);
            return RedirectToAction("CategoryTable");
        }
    }
}