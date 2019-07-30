using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using Shop.Core.Models;

namespace Shop.Data.InMemory
{
    public class ProductRepository
    {
        //Caching
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        //Constructor
        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null) {
                products = new List<Product>();
            }
        }

        //SAVE Product
        public void Commit() {
            cache["products"] = products;
        }

        //ADD Product
        public void Insert(Product p) {
            products.Add(p);
        }

        //UPDATE Product
        public void Update(Product product) {
            Product productToUpdate = products.Find(p => p.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
            else {
                throw new Exception("Product not found");
            }
        }

        //FIND Product
        public Product Find(string Id) {
            Product product = products.Find(p => p.Id == Id);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
        
        //CREATE Queryable Product Collections
        public IQueryable<Product> Collection() {
            return products.AsQueryable();
        }

        //DELETE Product
        public void Delete(string Id) {

            Product productToDelete = products.Find(p => p.Id == Id);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
