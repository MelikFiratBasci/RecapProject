using Core.Business;
using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService 
    {
        IDataResult<Brand> Get(int Id);
        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand entity);
        IResult Update(Brand entity);
        IResult Delete(Brand entity);
    }
}
