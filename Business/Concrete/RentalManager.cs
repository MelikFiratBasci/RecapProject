using Business.Abstract;
using Core.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAcces.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental entity)
        {
            
            var temp = _rentalDal.Get(c => c.CarId == entity.CarId);
            if (temp != null)
            {
                if (temp.ReturnDate == null)
                {
                    
                    return new ErorResult(Messages.ReturnDateEror);
                    
                }
                else
                {
                   
                    _rentalDal.Add(entity);
                    return new SuccessResult();
                }

            }
            else
            {
                _rentalDal.Add(entity);
                return new SuccessResult();
            }
           
            
           
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Rental> Get(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == Id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {

            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
           
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult();
        }

    }
}
