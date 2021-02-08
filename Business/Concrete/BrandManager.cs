using Business.Abstract;
using DataAcces.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal; 
        }
        public void Add(Brand entity)
        {
            if (entity.BrandName.Length <2 )
            {
                Console.WriteLine("Marka adi 2 karakterden buyuk olmalidir. ");
            }
            else
            {
                
                if (_brandDal.Get(a => a.BrandId == entity.BrandId) ==null)
                {
                    _brandDal.Add(entity);

                }
                else
                {
                    Console.WriteLine("Daha Onceden kayitli ID ");
                }
            }
        }

        public void Delete(Brand entity)
        {
            _brandDal.Delete(entity);
        }

        public Brand Get(int Id)
        {
            return _brandDal.Get(b =>b.BrandId==Id );
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();

        }

        public void Update(Brand entity)
        {
            if (entity.BrandName.Length > 2)
            {
                _brandDal.Update(entity);
                Console.WriteLine("guncellendi");
            }
            else
            {
                Console.WriteLine("Marka Adi 2 karakterden kucuk olamaz.");
            }
        }
    }
}
