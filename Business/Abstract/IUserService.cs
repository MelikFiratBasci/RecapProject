using Core.Business;
using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> Get(int Id);
        IDataResult<List<User>> GetAll();
        IResult Add(User entity);
        IResult Update(User entity);
        IResult Delete(User entity);
    }
}
