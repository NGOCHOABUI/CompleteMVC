using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.InMemory
{
    public class ProductCategoryRepository
    {
        //Caching
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        //Constructor
        public ProductCategoryRepository()
        {
            productCategories = cache["productsCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }

        //SAVE ProductCategory
        public void Commit()
        {
            cache["productsCategories"] = productCategories;
        }

        //ADD ProductCategory
        public void Insert(ProductCategory productCategory )
        {
            productCategories.Add(productCategory);
        }

        //UPDATE ProductCategory
        public void Update(ProductCategory productCategory)
        {
            ProductCategory productCategoryToUpdate = productCategories.Find(p => p.Id == productCategory.Id);
            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product Category not found");
            }
        }

        //FIND Product Category
        public ProductCategory Find(string Id)
        {
            ProductCategory productCategory = productCategories.Find(p => p.Id == Id);
            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Product Category not found");
            }
        }

        //CREATE Queryable Product Collections
        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        //DELETE Product Category
        public void Delete(string Id)
        {

            ProductCategory productCategoryToDelete = productCategories.Find(p => p.Id == Id);
            if (productCategoryToDelete != null)
            {
                productCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product Category not found");
            }
        }
    }
}
