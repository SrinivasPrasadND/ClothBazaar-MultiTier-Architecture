using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothBazar.Web.ViewModels
{
    public class CheckOutViewmodels
    {
        public List<Product> CartProducts { get; set; }
        public List<int> CartProductIds { get; set; }
    }
}