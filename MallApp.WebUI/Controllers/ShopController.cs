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
        public IActionResult List(string? text,string? category)
        {
            var products = new ProductListModel()
            {
                Products = _productService.GetAll(),
                Text = text,
                ProductCount = _productService.ProductCount()
            };

            if (text != null)
            {
                products.Products = _productService.GetProductsByName(text);
                products.Text = text;
                products.ProductCount = _productService.GetProductsByName(text).Count();
                return View(products);
            }
            if (category != null)
            {
                products.Products = _productService.GetProductsByCategory(category);
            }

           
                return View(products);
            



        }
    }
}