using ClothBazar.Database;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ClothBazar.Services
{
    
    public class ProductsService
    {
        #region Singleton
        public static ProductsService Instance {
            get
            {
                if (MyInstance == null) MyInstance = new ProductsService();
                return MyInstance;
            }
        }
        private static ProductsService MyInstance { get; set; }

        private ProductsService()
        { }

        #endregion

        public List<Product> GetAllProducts()
        {

            using (var context = new CBContext())
            {
                return context.Products.Include(x => x.Category).ToList();

            }
        }

        public List<Product> GetProducts(int pageNo)
        {
            int pageSize =10;

            using (var context = new CBContext())
            {
                return context.Products.OrderBy(x=>x.ID).Skip((pageNo-1)*pageSize).Take(pageSize).Include(x => x.Category).ToList();

            }
        }

        public Product GetProduct(int ID)
        {
            using (var context = new CBContext())
            {
                return context.Products.Find(ID);
            }

        }

        public List<Product> GetProducts(List<int> IDs)
        {
            using (var context = new CBContext())
            {
                return context.Products.Where(pro => IDs.Contains(pro.ID)).ToList();
            }

        }

        public void SaveProduct(Product product)
        {
            using (var context = new CBContext())
            {
                context.Entry(product.Category).State = EntityState.Unchanged;

                context.Products.Add(product);
                context.SaveChanges();
            }      

        }

        public void UpdateProduct(Product product)
        {
            using (var context = new CBContext())
            {
               //context.Entry(product.Category).State = EntityState.Modified;
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int ID)
        {
            using (var context = new CBContext())
            {
                var pro = context.Products.Find(ID);
                context.Products.Remove(pro);

                context.SaveChanges();
            }
        }
    }
}
