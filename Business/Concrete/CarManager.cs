using Business.Abstract;
using Core.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
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


        public IResult Add(Car entity)
        {

            if (entity.DailyPrice > 0)
            {

                if (_carDal.Get(a => a.Id == entity.Id) == null)
                {

                    _carDal.Add(entity);
                   
                    return new Result(true, Messages.ProductAdded);
                }
                else
                {
                    return new Result(false, Messages.IdEror);
                }
            }
            else
            {

                return new Result(false, Messages.PriceEror);
            }
        }

        public IResult Delete(Car entity)
        {
            
            if (_carDal.Get(c => c.Id ==entity.Id ) == null)
            {
                return new Result(false, Messages.IdEror);
            }
            else
            {
                return new Result(true, Messages.ProductDeleted);
            }
        }

      

        public IDataResult<Car> Get(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == Id));
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }
        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.BrandId == brandId));
        } 
        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return  new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Update(Car entity)
        {
            if (entity.DailyPrice>0)
            {
                _carDal.Update(entity);
                return new SuccessResult(Messages.ProductUpdated);
            }
            else
            {
                return new ErorResult(Messages.PriceEror);
            
            }
        }
    }
}
