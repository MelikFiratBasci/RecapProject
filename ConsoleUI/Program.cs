using Business.Concrete;
using DataAcces.Concrete.EntityFramework;
using Entity.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car { Id = 4, BrandId = 1, ColorId = 3, DailyPrice = 4, Description = "Test", ModelYear = 2020 };
            Brand brand1 = new Brand { BrandId = 4, BrandName = "as" };


            CarManager carManager = new CarManager(new EFCarDal());
            carManager.Add(car1);
            foreach (var item in carManager.GetByBrandId(1))
            {
                Console.WriteLine("{0},  ,{1}", item.Description, item.Id);
            }
            
        }
    }
}
