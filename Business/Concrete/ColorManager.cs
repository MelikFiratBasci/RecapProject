using Business.Abstract;
using Core.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAcces.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color entity)
        {
            if (_colorDal.Get(c => c.ColorId == entity.ColorId) == null)
            {
                _colorDal.Add(entity);
                return new SuccessResult();
            }
            else
            {
                return new ErorResult(Messages.IdEror);
            }
        }

        public IResult Delete(Color entity)
        {
            if (_colorDal.Get(c => c.ColorId == entity.ColorId) == null)
            {
                return new ErorResult(Messages.IdEror);
            }
            else
            {
                _colorDal.Delete(entity);
                return new SuccessResult();
            }
        }

        public IDataResult<Color>Get(int Id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == Id));
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>( _colorDal.GetAll());

        }

        public IResult Update(Color entity)
        {
            if (_colorDal.Get(c=> c.ColorId == entity.ColorId) == null)
            {
                return new ErorResult(Messages.IdEror);
            }
            else
            {
                _colorDal.Update(entity);
                return new SuccessResult();
            }
        }
    }
}
