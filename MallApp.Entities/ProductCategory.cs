﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MallApp.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
