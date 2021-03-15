using MallApp.Business.Abstract;
using MallApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MallApp.WebUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        public ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync() 
        {

            return View(new CategoryListViewModel() 
            {
            Categories = _categoryService.GetAll()
            } );
        }
    }
}
