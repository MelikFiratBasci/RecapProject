﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.Business;
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
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        [TransactionScopeAspect]
        public IResult Add(Rental entity)
        {

            IResult result = BusinessRules.Run(CheckIfCarRent(entity));
            if (result != null)
            {
                return result;
            }
             _rentalDal.Add(entity);
            return new SuccessResult();
        }

        [SecuredOperation("rental.delete,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental entity)
        {
            var result = _rentalDal.Get(c => c.RentalId == entity.RentalId);
            if (result == null)
            {
                return new ErrorResult(Messages.IdEror);
            }
            _rentalDal.Delete(result);
            return new SuccessResult(Messages.ProductDeleted);
        }
        [CacheAspect]
        public IDataResult<Rental> Get(int id)
        {
            var result = _rentalDal.Get(c => c.RentalId == id);
            if (result == null)
            {
                return new ErrorDataResult<Rental>(Messages.IdEror);
            }
            return new SuccessDataResult<Rental>(result, Messages.EntitiesListed);
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(result, Messages.EntitiesListed);
        }
        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            var result = _rentalDal.GetRentalDetails();
            return new SuccessDataResult<List<RentalDetailDto>>(result, Messages.EntitiesListed);

        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int carId)
        {
            var result = _rentalDal.GetRentalDetails(r => r.CarId == carId);
            return new SuccessDataResult<List<RentalDetailDto>>(result);
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        [TransactionScopeAspect]
        public IResult Update(Rental entity)
        {
            var result = _rentalDal.Get(c => c.RentalId == entity.RentalId);
            if (result == null)
            {
                return new ErrorResult(Messages.IdEror);
            }
            _rentalDal.Update(result);
            return new SuccessResult(Messages.ProductUpdated);
        }
        private IResult CheckIfCarRent(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId);
            if (result!=null &&(result.ReturnDate == null || result.ReturnDate > rental.RentDate))
            {
                return new ErrorResult(Messages.ReturnDateEror);
            }
            return new SuccessResult();
        }

    }
}
