using ClothBazar.Services;
using ClothBazar.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class ShopController : Controller
    {

        public ActionResult Index()
        {
            AllProductVM allProduct = new AllProductVM();
            allProduct.Products = ProductsService.Instance.GetAllProducts().Take(9).ToList();
            return View(allProduct);
        }

        //ProductsService productsService = new ProductsService(); 
        // GET: Shop
        public ActionResult CheckOut()
        {
            CheckOutViewmodels model = new CheckOutViewmodels();  
            var cartProductCookie = Request.Cookies["CartProducts"];
            if (cartProductCookie != null)
            {
                model.CartProductIds = cartProductCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();

                model.CartProducts = ProductsService.Instance.GetProducts(model.CartProductIds);
            }
            return View(model);
        }
    }
}