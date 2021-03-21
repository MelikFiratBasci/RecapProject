using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAcces.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using FluentValidation;
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
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car entity)
        {
            var result = _carDal.Get(a => a.Id == entity.Id);
            if (result == null)
            {

                _carDal.Add(entity);

                return new SuccessResult(Messages.ProductAdded);
            }
            else
            {
                return new ErrorResult(Messages.IdEror);
            }

        }
        [SecuredOperation("car.delete,admin")]
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


        [SecuredOperation("get,admin")]
        public IDataResult<Car> Get(int Id)
        {
            var result = _carDal.Get(c => c.Id == Id);
            if (result != null)
            {
                return new SuccessDataResult<Car>(result, Messages.EntitiesListed);
            }
            return new ErrorDataResult<Car>(Messages.IdEror);

        }
        [SecuredOperation("get,admin")]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.EntitiesListed);
        }
        [SecuredOperation("get,admin")]
        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Car>>(Messages.IdEror);
            }
            return new SuccessDataResult<List<Car>>(result, Messages.EntitiesListed);
        }
        [SecuredOperation("get,admin")]
        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<Car>>(Messages.IdEror);
            }
            return new SuccessDataResult<List<Car>>(result, Messages.EntitiesListed);

        }
        [SecuredOperation("get,admin")]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
        [SecuredOperation("car.update,admin")]
        [ValidationAspect(typeof(CarValidator))]
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
