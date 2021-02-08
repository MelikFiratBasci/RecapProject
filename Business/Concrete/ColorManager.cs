using Business.Abstract;
using DataAcces.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color entity)
        {
            if (_colorDal.Get(c => c.ColorId == entity.ColorId) == null)
            {
                _colorDal.Add(entity);
            }
            else
            {
                Console.WriteLine("Daha once kayitli Id ");
            }
        }

        public void Delete(Color entity)
        {
            if (_colorDal.Get(c => c.ColorId == entity.ColorId) == null)
            {
                Console.WriteLine("Hatali islem" );
            }
            else
            {
                _colorDal.Delete(entity);
            }
        }

        public Color Get(int Id)
        {
            return _colorDal.Get(c => c.ColorId == Id);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public void Update(Color entity)
        {
            if (_colorDal.Get(c=> c.ColorId == entity.ColorId) == null)
            {
                Console.WriteLine("Hatali islem");
            }
            else
            {
                _colorDal.Update(entity);
            }
        }
    }
}
