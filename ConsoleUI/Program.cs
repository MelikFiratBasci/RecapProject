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
            //Car car1 = new Car { Id = 4, BrandId = 1, ColorId = 3, DailyPrice = 4, Description = "Test", ModelYear = 2020 };
            //Brand brand1 = new Brand { BrandId = 4, BrandName = "as" };


            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0},  ,{1},     ,{3 }  , {4 }   ", item.Id, item.BrandName,item.ColorName,item.DailyPrice,item.Description);
            }

            
        }
    }
}
