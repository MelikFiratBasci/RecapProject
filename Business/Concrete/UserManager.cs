using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAcces.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User entity)
        {
            var result = _userDal.Get(c => c.UserId == entity.UserId);
            if (result != null)
            {
                return new ErrorResult(Messages.IdEror);
            }
            _userDal.Add(entity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(User entity)
        {
            var result = _userDal.Get(c => c.UserId == entity.UserId);
            if (result == null)
            {
                return new ErrorResult(Messages.IdEror);
            }
            _userDal.Delete(entity);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<User> Get(int id)
        {
            var result = _userDal.Get(c => c.UserId == id);
            if (result == null)
            {
                return new ErorDataResult<User>(Messages.IdEror);
            }
            return new SuccessDataResult<User>(result, Messages.EntitiesListed);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();

            return new SuccessDataResult<List<User>>(result, Messages.EntitiesListed);
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User entity)
        {
            var result = _userDal.Get(c => c.UserId == entity.UserId);
            if (result == null)
            {
                return new ErrorResult(Messages.IdEror);
            }
            _userDal.Update(entity);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
