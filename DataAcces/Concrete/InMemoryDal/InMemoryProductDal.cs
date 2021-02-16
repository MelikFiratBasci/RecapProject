//using DataAcces.Abstract;
//using Entity.Concrete;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;

//namespace DataAcces.Concrete.InMemoryDal
//{
//    public class InMemoryProductDal : ICarDal
//    {
//        //List<Car> _cars;

//        //public InMemoryProductDal()
//        //{
//        //    _cars = new List<Car>
//        //    {;;;
//        //        new Car{Id=1 , CategoryId=1 , DailyPrice=25,Description= "klimali",ModelYear=2010},
//        //        new Car{Id=2 , CategoryId=2 , DailyPrice=35,Description= "klimali",ModelYear=2017},
//        //        new Car{Id=3 , CategoryId=1 , DailyPrice=50,Description= "klimali",ModelYear=2018},
//        //        new Car{Id=4 , CategoryId=2 , DailyPrice=20,Description= "klimali",ModelYear=2009},
//        //        new Car{Id=5 , CategoryId=1 , DailyPrice=60,Description= "klimali",ModelYear=2015},
//        //        new Car{Id=6 , CategoryId=2 , DailyPrice=100,Description= "klimali",ModelYear=2020}
//        //    };
//        //}

//        //public void Add(Car car)
//        //{
//        //    _cars.Add(car);
//        //}

//        //public void Delete(Car car)
//        //{
//        //    Car carToDelete;
//        //    carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
//        //    _cars.Remove(carToDelete);
//        //}

//        //public List<Car> GetAll()
//        //{
//        //    return _cars;
//        //}

//        //public List<Car> GetById(int Id)
//        //{
//        //    return _cars.Where(c => c.Id == Id).ToList();
//        //}

//        //public void Update(Car car)
//        //{
//        //    Car carToUpdate;
//        //    carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
//        //    carToUpdate.CategoryId = car.CategoryId;
//        //    carToUpdate.ColorId = car.ColorId;
//        //    carToUpdate.DailyPrice = car.DailyPrice;
//        //    carToUpdate.Description = car.Description;
//        //    carToUpdate.ModelYear = car.ModelYear;

//        //}
//        public void Add(Car entity)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(Car entity)
//        {
//            throw new NotImplementedException();
//        }

//        public Car Get(Expression<Func<Car, bool>> filter)
//        {
//            throw new NotImplementedException();
//        }

//        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(Car entity)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
