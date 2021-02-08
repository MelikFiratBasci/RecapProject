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
    public class EFCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (MyRentaCarSqlServerContext context = new MyRentaCarSqlServerContext())
            {
                var addedCar = context.Entry(entity);
                addedCar.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (MyRentaCarSqlServerContext context = new MyRentaCarSqlServerContext())
            {
                var deletedCar = context.Entry(entity);
                deletedCar.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (MyRentaCarSqlServerContext context = new MyRentaCarSqlServerContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);

            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (MyRentaCarSqlServerContext context = new MyRentaCarSqlServerContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();

            }
        }

        public void Update(Car entity)
        {
            using (MyRentaCarSqlServerContext context = new MyRentaCarSqlServerContext())
            {
                var updatedCar = context.Entry(entity);
                updatedCar.State = EntityState.Modified;
                context.SaveChanges();

            }

        }
    }
}
