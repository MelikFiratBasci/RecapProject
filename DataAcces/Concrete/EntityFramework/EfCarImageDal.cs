﻿using Core.DataAccess.EntityFramework;
using DataAcces.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcces.Concrete.EntityFramework
{
    public class EfCarImageDal:EfEntityRepositoryBase<CarImage,MyRentaCarSqlServerContext>,ICarImageDal
    {
    }
}
