using Core.DataAccess.EntityFramework;
using DataAcces.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAcces.Concrete.EntityFramework
{
    public class EFColorDal : EfRepositoryBase<Color,MyRentaCarSqlServerContext>,IColorDal
    {
       
    }
}
