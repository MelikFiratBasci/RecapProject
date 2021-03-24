using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAcces.Abstract;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Add(Color entity)
        {
            var result = _colorDal.Get(c => c.ColorId == entity.ColorId);
            if (result == null)
            {
                _colorDal.Add(entity);
                return new SuccessResult(Messages.ProductAdded);
            }
            else
            {
                return new ErrorResult(Messages.IdEror);
            }
        }
        [SecuredOperation("car.delete,admin")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Delete(Color entity)
        {
            var result = _colorDal.Get(c => c.ColorId == entity.ColorId);
            if (result == null)
            {
                return new ErrorResult(Messages.IdEror);
            }
            else
            {
                _colorDal.Delete(entity);
                return new SuccessResult(Messages.ProductDeleted);
            }
        }

        [SecuredOperation("get,admin")]
        [CacheAspect]
        public IDataResult<Color>Get(int Id)
        {
            var result = _colorDal.Get(c => c.ColorId == Id );
            return new SuccessDataResult<Color>(result,Messages.EntitiesListed);
        }
        [SecuredOperation("get,admin")]
        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {   
            var result = _colorDal.GetAll();
            return new SuccessDataResult<List<Color>>( result);

        }
        [SecuredOperation("car.update,admin")]

        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Update(Color entity)
        {
            var result = _colorDal.Get(c => c.ColorId == entity.ColorId);
            if (result ==  null)
            {
                return new ErrorResult(Messages.IdEror);
            }
            else
            {
                _colorDal.Update(entity);
                return new SuccessResult(Messages.ProductUpdated);
            }
        }
    }
}
