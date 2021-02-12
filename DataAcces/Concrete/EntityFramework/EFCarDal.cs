using Core.DataAccess.EntityFramework;
using DataAcces.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System.Collections.Generic;
using System.Linq;

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
                             join col in carSqlServerContext.Colors
                             on c.ColorId equals col.ColorId
                             
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ColorName = col.ColorName
                             };
                return result.ToList(); 
                             
                             
            }
        }
    }
}
