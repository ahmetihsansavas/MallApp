using MallApp.DataAccess.Abstract;
using MallApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MallApp.DataAccess.Concrete.EfCore
{
  
    class EfCoreCategoryDal : EfCoreGenericRepository<Category,MallContext>,ICategoryDal 
    {
       
    }
}
