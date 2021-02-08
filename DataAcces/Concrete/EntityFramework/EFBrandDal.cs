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
    public class EFBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (MyRentaCarSqlServerContext context = new MyRentaCarSqlServerContext())
            {
                var addedBrand = context.Entry(entity);
                addedBrand.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (MyRentaCarSqlServerContext context = new MyRentaCarSqlServerContext())
            {
                var deletedBrand = context.Entry(entity);
                deletedBrand.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (MyRentaCarSqlServerContext context = new MyRentaCarSqlServerContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (MyRentaCarSqlServerContext context = new MyRentaCarSqlServerContext())
            {
                return filter == null
                    ? context.Set<Brand>().ToList()
                    : context.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
        {
            using (MyRentaCarSqlServerContext context = new MyRentaCarSqlServerContext())
            {
                var updatedBrand = context.Entry(entity);
                updatedBrand.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
