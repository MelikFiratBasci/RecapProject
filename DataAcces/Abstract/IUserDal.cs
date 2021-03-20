using Core.DataAccess;
using Core.Entities.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcces.Abstract
{
    public interface IUserDal :IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user); 
    }
}
