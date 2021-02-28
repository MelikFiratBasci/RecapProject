using Core.Business;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService 
    {
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<Car>> GetByColorId(int colorId);
        IDataResult<Car> Get(int Id);
        IDataResult<List<Car>> GetAll();
        IResult Add(Car entity);
        IResult Update(Car entity);
        IResult Delete(Car entity);

    }
}
