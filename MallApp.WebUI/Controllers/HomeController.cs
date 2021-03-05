using MallApp.Business.Abstract;
using MallApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MallApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public HomeController(IProductService productService , ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetPopularProducts() ,
                ProductCount = _productService.ProductCount()

            }) ;
        }
    }
}
