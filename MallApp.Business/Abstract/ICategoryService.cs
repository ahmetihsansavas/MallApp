﻿using MallApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MallApp.Business.Abstract
{
  public  interface ICategoryService
    {
        Category GetById(int id);
        List<Category> GetAll();
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
    }
}
