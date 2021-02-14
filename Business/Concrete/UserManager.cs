using Business.Abstract;
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

        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult();      
        }

        public IDataResult<User> Get(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == Id));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult <List<User>>(_userDal.GetAll());
        }

        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult();    
        }
    }
}
