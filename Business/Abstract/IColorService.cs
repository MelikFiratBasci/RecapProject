using Core.Utilities.Results;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IColorService 
    {
        IDataResult<Color> Get(int Id);
        IDataResult<List<Color>> GetAll();
        IResult Add(Color entity);
        IResult Update(Color entity);
        IResult Delete(Color entity);
    }
}
