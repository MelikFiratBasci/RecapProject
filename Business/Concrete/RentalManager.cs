﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAcces.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental entity)
        {

            var result = _rentalDal.Get(c => c.CarId == entity.CarId);
            if (result != null)
            {
                if (result.ReturnDate == null)
                {

                    return new ErorResult(Messages.ReturnDateEror);

                }
                else
                {

                    _rentalDal.Add(entity);
                    return new SuccessResult(Messages.ProductAdded);
                }

            }
            else
            {
                _rentalDal.Add(entity);
                return new SuccessResult(Messages.ProductAdded);
            }



        }

        public IResult Delete(Rental entity)
        {
            var result = _rentalDal.Get(c => c.RentalId == entity.RentalId);
            if (result == null)
            {
                return new ErorResult(Messages.IdEror);
            }
            _rentalDal.Delete(result);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<Rental> Get(int id)
        {
            var result = _rentalDal.Get(c => c.RentalId == id);
            if (result == null)
            {
                return new ErorDataResult<Rental>(Messages.IdEror);                
            }
            return new SuccessDataResult<Rental>(result, Messages.EntitiesListed);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(result, Messages.EntitiesListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            var result = _rentalDal.GetRentalDetails(); 
            return new SuccessDataResult<List<RentalDetailDto>>(result,Messages.EntitiesListed);

        }

        public IResult Update(Rental entity)
        {
            var result = _rentalDal.Get(c => c.RentalId == entity.RentalId);
            if (result == null)
            {
                return new ErorResult(Messages.IdEror);
            }
            _rentalDal.Update(result);
            return new SuccessResult(Messages.ProductUpdated);
        }

    }
}
