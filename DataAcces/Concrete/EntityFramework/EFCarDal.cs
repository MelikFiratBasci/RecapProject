using Core.DataAccess.EntityFramework;
using DataAcces.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAcces.Concrete.EntityFramework
{
    public class EFCarDal : EfEntityRepositoryBase<Car, MyRentaCarSqlServerContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (MyRentaCarSqlServerContext carSqlServerContext = new MyRentaCarSqlServerContext())
            {
                var result = from c in carSqlServerContext.Cars
                             join b in carSqlServerContext.Brands
                             
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList(); 
                             
                             
            }
        }
    }
}
