using Business.Concrete;
using Core.Entities.Concrete;
using DataAcces.Concrete.EntityFramework;
using Entity.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            Rental rental1 = new Rental() {CarId=4,CustomerId=1,RentDate = DateTime.Now };
            Rental rental2 = new Rental() {CarId=1,CustomerId=1,RentDate = DateTime.Now };
            Rental rental3 = new Rental() {CarId=3,CustomerId=1,RentDate = DateTime.Today.AddDays(-2),ReturnDate = DateTime.Today.AddDays(-1) };
            Rental rental4 = new Rental() {CarId=4,CustomerId=1,RentDate = DateTime.Today.AddDays(-1),ReturnDate = DateTime.Today.AddDays(-1) };
            Rental rental5 = new Rental() { CarId = 1, CustomerId = 1, RentDate = DateTime.Now };


            //UserAdd();
            //user1.Add(user);
            //CustomerAdd();

            //CarManager carManager = new CarManager(new EFCarDal());
            //GetcarDetails(carManager);
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(rental5);
            Console.WriteLine(rentalManager.Add(rental5).Message);
            //rentalManager.Add(rental3);
            //rentalManager.Add(rental4);
            foreach (var item in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine(item.RentalId);
            }

        }

        //private static void UserAdd()
        //{
        //    User user = new User { UserId = 1, Password = "asfsaf" };
        //    UserManager user1 = new UserManager(new EfUserDal());
        //}

        private static void CustomerAdd()
        {
            Customer customer = new Customer { CompanyName = "Company1", UserId = 1 };
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(customer);
        }

        private static void GetcarDetails(CarManager carManager)
        {
            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0},  ,{1},     ,{3 }  , {4 }   ", item.Id, item.BrandName, item.ColorName, item.DailyPrice, item.Description);
            }
        }
    }
}
