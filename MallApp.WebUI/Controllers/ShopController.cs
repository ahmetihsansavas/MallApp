using MallApp.Business.Abstract;
using MallApp.Entities;
using MallApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MallApp.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;
        public ShopController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = _productService.GetProductDetails((int)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(new ProductDetailsModel() 
            {
               Product = product,
               Categories = product.ProductCategories.Select(i=>i.Category).ToList()
            });
        }

       // [Route("Shop/List")]
       // [Route("Shop/List/{text?}")]
       //products/telefon?page=2
        public IActionResult List(string? text,string? category,int page=1)
        {
            const int pageSize = 5;
            var products = new ProductListModel()
            {
                Products = _productService.GetAll(),
                Text = text,
                ProductCount = _productService.ProductCount(),
                PageInfo = new PageInfo()
                {
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                }

            };

            if (text != null)
            {
                products.Products = _productService.GetProductsByName(text);
                products.Text = text;
                products.ProductCount = _productService.GetProductsByName(text).Count();
                return View(products);
            }
            if (category != null )
            {
                products.Products = _productService.GetProductsByCategory(category,page,pageSize);
                products.ProductCount = products.Products.Count();
                return View(products);
            }
            if (page >= 1)
            {
                products.Products = _productService.GetProductsByCategory(category, page, pageSize);
                products.ProductCount = products.Products.Count();
                
                return View(products);
            }

           
                return View(products);
            



        }
    }
}