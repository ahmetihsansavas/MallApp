using MallApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MallApp.WebUI.Models
{
    public class ProductListModel
    {
        public List<Product> Products { get; set; }

        public List<Category> Categories { get; set; }
        public int ProductCount { get; set; }
    }
}
