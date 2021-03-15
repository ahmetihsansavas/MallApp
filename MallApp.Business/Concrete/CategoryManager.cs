using MallApp.Business.Abstract;
using MallApp.DataAccess.Abstract;
using MallApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MallApp.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal  _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
