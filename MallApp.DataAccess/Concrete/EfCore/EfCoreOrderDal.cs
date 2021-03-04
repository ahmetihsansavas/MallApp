using MallApp.DataAccess.Abstract;
using MallApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MallApp.DataAccess.Concrete.EfCore
{
   public class EfCoreOrderDal:EfCoreGenericRepository<Order,MallContext>,IOrderDal
    {
    }
}
