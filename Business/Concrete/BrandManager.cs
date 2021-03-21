using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAcces.Abstract;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand entity)
        {

            var result = _brandDal.Get(a => a.BrandId == entity.BrandId);
            if (result == null)
            {
                _brandDal.Add(entity);
                return new SuccessResult(Messages.ProductAdded);

            }

            return new ErrorResult(Messages.IdEror);

        }
        [SecuredOperation("car.delete,admin")]
        public IResult Delete(Brand entity)
        {
            var result = _brandDal.Get(a => a.BrandId == entity.BrandId);
            if (result == null)
            {
                return new ErrorResult(Messages.IdEror);
            }
            _brandDal.Delete(entity);
            return new SuccessResult(Messages.ProductDeleted);
        }
        [SecuredOperation("get,admin")]
        public IDataResult<Brand> Get(int Id)
        {
            var result = _brandDal.Get(b => b.BrandId == Id);
            if (result == null)
            {
                return new ErrorDataResult<Brand>(Messages.IdEror);
            }
            return new SuccessDataResult<Brand>(result, Messages.EntitiesListed);
        }
        [SecuredOperation("get,admin")]

        public IDataResult<List<Brand>> GetAll()
        {
            var result = _brandDal.GetAll();
            return new SuccessDataResult<List<Brand>>(result, Messages.EntitiesListed);

        }
        [SecuredOperation("car.update,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand entity)
        {
            _brandDal.Update(entity);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
