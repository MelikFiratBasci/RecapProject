using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAcces.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System.Collections.Generic;

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
                   
                    return new SuccessResult(Messages.ProductAdded);
                }
                else
                {
                    return new ErorResult(Messages.IdEror);
                }
            }
            else
            {

                return new SuccessResult(Messages.PriceEror);
            }
        }

        public IResult Delete(Car entity)
        {
            
            if (_carDal.Get(c => c.Id ==entity.Id ) == null)
            {
                return new ErorResult(Messages.IdEror);
            }
            else
            {
                return new SuccessResult(Messages.ProductDeleted);
            }
        }

      

        public IDataResult<Car> Get(int Id)
        {
            var result = _carDal.Get(c => c.Id == Id);
            if (result!=null)
            {
                return new SuccessDataResult<Car>(result,Messages.EntitiesListed);
            }
            return new ErorDataResult<Car>(Messages.IdEror);
            
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.EntitiesListed);
        }
        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId);
            if (result.Count ==  0 )
            {
                return new ErorDataResult<List<Car>>(Messages.IdEror);
            }
            return new SuccessDataResult<List<Car>>(result,Messages.EntitiesListed);
        } 
        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId);
            if (result.Count == 0)
            {
                return new ErorDataResult<List<Car>>(Messages.IdEror);
            }
            return new SuccessDataResult<List<Car>>(result,Messages.EntitiesListed);
          
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
