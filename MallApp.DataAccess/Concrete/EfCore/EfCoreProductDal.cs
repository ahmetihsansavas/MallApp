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
