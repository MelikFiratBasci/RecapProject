using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAcces.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;
        public CarManager(ICarDal carDal,ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }
       // [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car entity)
        {
            
            var result = _carDal.Get(a => a.Id == entity.Id);
            if (result == null)
            {
                _carDal.Add(entity);
                _carImageService.SetDefaultImage(entity.Id);
                return new SuccessResult(Messages.ProductAdded);
            }
            else
            {
                return new ErrorResult(Messages.IdEror);
            }

        }
        [SecuredOperation("car.delete,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car entity)
        {
            var result = _carDal.Get(a => a.Id == entity.Id);
            if (result == null)
            {
                return new ErrorResult(Messages.IdEror);
            }
            else
            {
                return new SuccessResult(Messages.ProductDeleted);
            }
        }

        
        public IDataResult<Car> Get(int Id)
        {
            var result = _carDal.Get(c => c.Id == Id);
            if (result != null)
            {
                return new SuccessDataResult<Car>(result, Messages.EntitiesListed);
            }
            return new ErrorDataResult<Car>(Messages.IdEror);

        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.EntitiesListed);
        }
        public IDataResult<List<CarDetailDto>> GetByBrandId(int brandId)
        {
            var result = _carDal.GetCarDetails().Where(c=>c.BrandId==brandId).ToList();
            if (result ==null) 
            {
                return new SuccessDataResult<List<CarDetailDto>>(Messages.IdEror);
            }
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.EntitiesListed);
        }
        
        public IDataResult<List<CarDetailDto>> GetByColorId(int colorId)
        {
            var result = _carDal.GetCarDetails().Where(c => c.ColorId == colorId).ToList();
            if (result ==null)
            {
                return new SuccessDataResult<List<CarDetailDto>>(Messages.IdEror);
            }
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.EntitiesListed);

        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {  

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
        [CacheAspect]
        public IDataResult<CarDetailDto> GetCarWithDetails(int id)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarWithDetails(c=>c.Id==id));
        }
        public IDataResult<List<CarDetailDto>> GetCarsbyBrandandColor(int brandId,int colorId)
        {
            var result = _carDal.GetCarDetails(c => c.BrandId == brandId && c.ColorId == colorId);
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }
        [SecuredOperation("car.update,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        public IResult Update(Car entity)
        {
            var result = _carDal.Get(a => a.Id == entity.Id);
            if (result == null)
            {
                _carDal.Update(entity);
                return new SuccessResult(Messages.ProductUpdated);
            }
            else
            {
                return new ErrorResult(Messages.PriceEror);

            }
        }
    }
}
