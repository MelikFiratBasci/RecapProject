using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<CarImage> Get(int Id);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetAllByCarId(int id);
        IResult Add(IFormFile formFile,CarImage entity);
        IResult Update(IFormFile formFile,CarImage entity);
        IResult Delete(CarImage entity);
        void SetDefaultImage(int carId);
    }
}
