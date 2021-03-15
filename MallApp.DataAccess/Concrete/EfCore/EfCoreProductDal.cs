using MallApp.DataAccess.Abstract;
using MallApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MallApp.DataAccess.Concrete.EfCore
{
    public class EfCoreProductDal : EfCoreGenericRepository<Product, MallContext>, IProductDal
    {
        public int GetCountByCategory(string category)
        {
            using (var context = new MallContext())
            {
                var products = context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                        .Include(i => i.ProductCategories)
                                        .ThenInclude(i => i.Category)
                                        .Where(i => i.ProductCategories.Any(a =>a.Category.Name.ToLower()==category.ToLower()) );
                            
                }
                return products.Count();
            }
        }

        public IEnumerable<Product> GetPopularProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductDetails(int id)
        {
            using (var context = new MallContext())
            {
                return context.Products
                                .Where(i => i.Id == id)
                                .Include(i => i.ProductCategories)
                                .ThenInclude(i => i.Category)
                                .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string category,int page,int pageSize)
        {
            using (var context = new MallContext())
            {
                var products = context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                       .Include(i => i.ProductCategories)
                                       .ThenInclude(i => i.Category)
                                       .Where(i => i.ProductCategories.Any(a=>a.Category.Name.ToLower() == category.ToLower()));
                }
                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Product> GetProductsByName(string text)
        {
            using (var context = new MallContext())
            {
                if (!string.IsNullOrEmpty(text))
                {
                    return context.Products.Where(i => i.Name.Contains(text)).ToList();
                }
                else
                {
                    return null;
                }
            
            }
        }

        public int ProductCount()
        {
            using (var context = new MallContext())
            {
                return context.Products.Count();
            }
        }
    }
}
