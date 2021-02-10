using Business.Abstract;
using DataAcces.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public void Add(Car entity)
        {

            if (entity.DailyPrice > 0)
            {

                if (_carDal.Get(a => a.Id == entity.Id) == null)
                {

                    _carDal.Add(entity);
                    Console.WriteLine("Araba eklendi! ");
                }
                else
                {
                    Console.WriteLine("Daha Onceden kayitli ID ");
                }
            }
            else
            {
                Console.WriteLine("Günlük Fiyat 0 dan büyük olmalıdır!");
            }
        }

        public void Delete(Car entity)
        {
            
            if (_carDal.Get(c => c.Id ==entity.Id ) == null)
            {
                Console.WriteLine("verdiginiz id kullanilmiyor {0} ",entity.Id);
            }
            else
            {
                _carDal.Delete(entity);
            }
        }

      

        public Car Get(int Id)
        {
            return _carDal.Get(c => c.Id == Id);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
        public List<Car> GetByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        } 
        public List<Car> GetByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car entity)
        {
            if (entity.DailyPrice>0)
            {
                _carDal.Update(entity);
                Console.WriteLine("Guncelleme tamamlandi");
            }
            else
            {
                Console.WriteLine("Gunluk ucret 0 dan buyuk olmalidir ");
            }
        }
    }
}
