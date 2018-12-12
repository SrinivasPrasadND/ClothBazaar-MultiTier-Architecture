using ClothBazar.Entities;
using ClothBazar.Services;
using ClothBazar.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class ProductController : Controller
    {
        //ProductsService productsService = new ProductsService();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductsTable(string search ,int? pageNo)
        {
            pageNo = pageNo.HasValue ? pageNo : 1;

            var products = ProductsService.Instance.GetProducts(pageNo.Value);

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            return PartialView(products);
        }

        // Create Products
        public ActionResult Create()
        {
            CategoriesService categoriesService = new CategoriesService();
            var categories = categoriesService.GetCategories();
           
            return PartialView(categories);
        }

        [HttpPost]
        public ActionResult Create(NewCategoryViewModels catModel)
         {
            CategoriesService categoriesService = new CategoriesService();
            var newProduct = new Product
            {
                Name = catModel.Name,
                Description = catModel.Description,
                Price = catModel.Price,
                ImageUrl=catModel.ImageUrl,

                Category = categoriesService.GetCategory(catModel.CategoryID)
            };


            ProductsService.Instance.SaveProduct(newProduct);
            return RedirectToAction("ProductsTable");
        }


        public ActionResult Edit(int ID)
        {
            CategoriesService categoriesService = new CategoriesService();
            var cats = categoriesService.GetCategories();
            ViewBag.Cats = cats;

            var product = ProductsService.Instance.GetProduct(ID);
            return PartialView(product);
        }

        [HttpPost]
        public ActionResult Edit(NewCategoryViewModels catModel)
        {
            CategoriesService categoriesService = new CategoriesService();
            var updateProduct = new Product
            {
                ID = catModel.ProductId,
                Name = catModel.Name,
                Description = catModel.Description,
                Price = catModel.Price,
                ImageUrl=catModel.ImageUrl,
                CategoryId = catModel.CategoryID,
                Category = categoriesService.GetCategory(catModel.CategoryID)
            };

            ProductsService.Instance.UpdateProduct(updateProduct);
            return RedirectToAction("ProductsTable");
        }

        //public ActionResult Delete(int ID)
        //{
        //    var product = productsService.GetProduct(ID);
        //    return PartialView(product);
        //}

        [HttpPost]
        public ActionResult Delete(int ID)
        {

            ProductsService.Instance.DeleteProduct(ID);
            return RedirectToAction("ProductsTable");
        }
    }
}