using ClothBazar.Services;
using ClothBazar.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
   
    public class HomeController : Controller
    {
        CategoriesService categoriesService = new CategoriesService();

        public ActionResult Index()
        {
            HomeViewModels models = new HomeViewModels();
            models.FeaturedCategories = categoriesService.GetFeaturedCategories();
            models.NewProducts = ProductsService.Instance.GetAllProducts().OrderByDescending(x=>x.ID).Take(4).ToList();
            return View(models);
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