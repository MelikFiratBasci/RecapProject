using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService 
    {
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetByColorId(int colorId);
        IDataResult<Car> Get(int Id);
        IDataResult<List<Car>> GetAll();
        IResult Add(Car entity);
        IResult Update(Car entity);
        IResult Delete(Car entity);
        IDataResult<CarDetailDto> GetCarWithDetails(int id);

    }
}
