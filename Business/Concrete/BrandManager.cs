using Business.Abstract;
using Core.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAcces.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal; 
        }
        public IResult Add(Brand entity)
        {
            if (entity.BrandName.Length <= 2 )
            {
                return new ErorResult(Messages.NameEror);
            }
            else
            {
                
                if (_brandDal.Get(a => a.BrandId == entity.BrandId) ==null)
                {
                    _brandDal.Add(entity);
                    return new SuccessResult();

                }
                else
                {
                    return new ErorResult(Messages.IdEror);
                }
            }
        }

        public IResult Delete(Brand entity)
        {
            _brandDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Brand> Get(int Id)
        {
            return new SuccessDataResult<Brand>( _brandDal.Get(b =>b.BrandId==Id ));
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());

        }

        public IResult Update(Brand entity)
        {
            if (entity.BrandName.Length > 2)
            {
                _brandDal.Update(entity);
                return new SuccessResult(Messages.ProductUpdated);

            }
            else
            {
                return new SuccessResult(Messages.NameEror);
            }
        }
    }
}
