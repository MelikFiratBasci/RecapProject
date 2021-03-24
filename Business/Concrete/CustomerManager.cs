using Business.Abstract;
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
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Customer entity)
        {
            var result = _customerDal.Get(c => c.CustomerId == entity.CustomerId);
            if (result != null)
            {
                return new ErrorResult(Messages.IdEror);
            }
            else if (_customerDal.Get(c => c.UserId == entity.UserId) != null)
            {
                return new ErrorResult(Messages.IdEror);

            }
            _customerDal.Add(entity);
            return new SuccessResult(Messages.ProductAdded);
        }
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(Customer entity)
        {
            var result = _customerDal.Get(c => c.CustomerId == entity.CustomerId);
            if (result == null)
            {
                return new ErrorResult(Messages.IdEror);
            }
            _customerDal.Delete(entity);
            return new SuccessResult(Messages.ProductDeleted);
        }
        [CacheAspect]
        public IDataResult<Customer> Get(int Id)
        {
            var result = _customerDal.Get(c => c.CustomerId == Id);
            if (result == null)
            {
                return new ErrorDataResult<Customer>(Messages.IdEror);
            }
            return new SuccessDataResult<Customer>(result, Messages.EntitiesListed);
        }
        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(result, Messages.EntitiesListed);
        }
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        [TransactionScopeAspect]
        public IResult Update(Customer entity)
        {
            var result = _customerDal.Get(c => c.CustomerId == entity.CustomerId);
            if (result == null)
            {
                return new ErrorResult(Messages.IdEror);
            }
            _customerDal.Update(entity);
            return new SuccessResult();
        }
    }
}
