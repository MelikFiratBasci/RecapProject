﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAcces.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq

namespace DataAcces.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, MyRentaCarSqlServerContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new MyRentaCarSqlServerContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.Id
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
