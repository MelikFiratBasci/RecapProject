using Core.Utilities.Results;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerService 
    {
        IDataResult<Customer> Get(int Id);
        IDataResult<List<Customer>> GetAll();
        IResult Add(Customer entity);
        IResult Update(Customer entity);
        IResult Delete(Customer entity);
    }
}
