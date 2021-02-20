using Business.Abstract;
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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        [ValidationAspect(typeof(ColorValidator))]
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
                return new ErorResult(Messages.IdEror);
            }
        }

        public IResult Delete(Color entity)
        {
            var result = _colorDal.Get(c => c.ColorId == entity.ColorId);
            if (result == null)
            {
                return new ErorResult(Messages.IdEror);
            }
            else
            {
                _colorDal.Delete(entity);
                return new SuccessResult(Messages.ProductDeleted);
            }
        }

        public IDataResult<Color>Get(int Id)
        {
            var result = _colorDal.Get(c => c.ColorId == Id );
            return new SuccessDataResult<Color>(result,Messages.EntitiesListed);
        }

        public IDataResult<List<Color>> GetAll()
        {   
            var result = _colorDal.GetAll();
            return new SuccessDataResult<List<Color>>( result);

        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color entity)
        {
            var result = _colorDal.Get(c => c.ColorId == entity.ColorId);
            if (result ==  null)
            {
                return new ErorResult(Messages.IdEror);
            }
            else
            {
                _colorDal.Update(entity);
                return new SuccessResult(Messages.ProductUpdated);
            }
        }
    }
}
