using MallApp.DataAccess.Abstract;
using MallApp.Entities;
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

        public int ProductCount()
        {
            using (var context = new MallContext())
            {
                return context.Products.Count();
            }
        }
    }
}
