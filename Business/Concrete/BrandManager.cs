using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Caching.Microsoft;
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
        [CacheRemoveAspect("IBrandService.Get")]
        //[SecuredOperation("car.add,admin")]
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
        [CacheRemoveAspect("IBrandService.Get")]
        [SecuredOperation("car.delete,admin")]
        [TransactionScopeAspect]
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
        [CacheAspect]
        
        public IDataResult<Brand> Get(int Id)
        {
            var result = _brandDal.Get(b => b.BrandId == Id);
            if (result == null)
            {
                return new ErrorDataResult<Brand>(Messages.IdEror);
            }
            return new SuccessDataResult<Brand>(result, Messages.EntitiesListed);
        }
        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            var result = _brandDal.GetAll();
            return new SuccessDataResult<List<Brand>>(result, Messages.EntitiesListed);

        }
        [CacheRemoveAspect("IBrandService.Get")]
        [SecuredOperation("car.update,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [TransactionScopeAspect]
        public IResult Update(Brand entity)
        {
            _brandDal.Update(entity);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
