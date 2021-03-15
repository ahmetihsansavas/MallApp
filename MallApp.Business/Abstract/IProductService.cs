using MallApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MallApp.Business.Abstract
{
   public interface IProductService
    {
        Product GetById(int id);
        Product GetProductDetails(int id);
        List<Product> GetAll();
        List<Product> GetPopularProducts();
        List<Product> GetProductsByName(string text);
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        int ProductCount();
    }
}
