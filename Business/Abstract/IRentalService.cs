using Core.Business;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService : IEntityService<Rental>
    {
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}
