using Core.DataAccess.EntityFramework;
using DataAcces.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAcces.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, MyRentaCarSqlServerContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (MyRentaCarSqlServerContext carSqlServerContext = new MyRentaCarSqlServerContext())
            {


                var result = from c in carSqlServerContext.Cars

                             join b in carSqlServerContext.Brands
                             on c.BrandId equals b.BrandId
                             join col in carSqlServerContext.Colors
                             on c.ColorId equals col.ColorId
                             //join img in carSqlServerContext.CarImages
                             // on c.Id equals img.CarId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ColorName = col.ColorName,
                                 BrandId = b.BrandId,
                                 ColorId = c.ColorId,
                                 ModelYear = c.ModelYear,
                                 ImagePath = (from img in carSqlServerContext.CarImages
                                              where (c.Id == img.CarId)
                                              select img.ImagePath.Replace("C:\\Users\\USER\\source\\repos\\RecapProject\\WebApi\\wwwroot\\", "")).ToArray()
                                               
                             };
                return filter == null ?
                    result.ToList() :
                    result.Where(filter).ToList();


            }
        }
        public CarDetailDto GetCarWithDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (MyRentaCarSqlServerContext carSqlServerContext = new MyRentaCarSqlServerContext())
            {


                var result = from c in carSqlServerContext.Cars

                             join b in carSqlServerContext.Brands
                             on c.BrandId equals b.BrandId
                             join col in carSqlServerContext.Colors
                             on c.ColorId equals col.ColorId
                             //join img in carSqlServerContext.CarImages
                             // on c.Id equals img.CarId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ColorName = col.ColorName,
                                 BrandId = b.BrandId,
                                 ColorId = c.ColorId,
                                 ModelYear = c.ModelYear,
                                 ImagePath = (from img in carSqlServerContext.CarImages
                                              where (c.Id == img.CarId)
                                              select img.ImagePath.Replace("C:\\Users\\USER\\source\\repos\\RecapProject\\WebApi\\wwwroot\\", "")).ToArray()
                                               
                             };
                return filter == null ?
                    result.SingleOrDefault() :
                    result.SingleOrDefault(filter);


            }
        }

        //img.ImagePath.Replace("C:\\Users\\USER\\source\\repos\\RecapProject\\WebApi\\wwwroot\\", "")
    }
}