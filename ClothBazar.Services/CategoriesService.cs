using ClothBazar.Database;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Services
{
    public class CategoriesService
    {
        public List<Category> GetCategories()
        {
            using (var context = new CBContext())
            {
                List<Product> products = new List<Product>();
                List<Category> categories = context.Categories.ToList();
                foreach (var item in categories)
                {
                   // ProductsService service = new ProductsService();
                    products = ProductsService.Instance.GetAllProducts().Where(x => x.Category.ID == item.ID).ToList();
                    item.Products = products;

                }

                return categories;
            }

        }

        public List<Category> GetFeaturedCategories()
        {
            using (var context = new CBContext())
            {
                return context.Categories.Where(x => x.IsFeatured && x.ImageUrl != null).ToList();
            }

        }

        public Category GetCategory(int ID)
        {
            using (var context = new CBContext())
            {
                return context.Categories.Find(ID);
            }

        }

        public void SaveCategory(Category category)
        {
            using (var context = new CBContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }      

        }

        public void UpdateCategory(Category category)
        {
            using (var context = new CBContext())
            {
                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCategory(int ID)
        {
           
            using (var context = new CBContext())
            {
                //ProductsService productsService = new ProductsService();
                List<Product> prolist = ProductsService.Instance.GetAllProducts().Where(x=>x.Category.ID == ID).ToList();
                foreach (var item in prolist)
                {
                    ProductsService.Instance.DeleteProduct(item.ID);
                }
                var cat = context.Categories.Find(ID);
                context.Categories.Remove(cat);

                context.SaveChanges();
            }
        }
    }
}
