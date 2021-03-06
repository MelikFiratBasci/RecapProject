﻿using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAcces.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(IFormFile formFile, CarImage entity)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitIsExceeded(entity.CarId),
                CheckIfFileTypeUnsupported(formFile));
            if (result != null)
            {
                return result;
            }

            entity.ImagePath = FileHelper.Add(formFile);
            entity.ImageDate = DateTime.Now;
            _carImageDal.Add(entity);
            return new SuccessResult();

        }
        [SecuredOperation("car.update,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        [TransactionScopeAspect]
        public IResult Update(IFormFile formFile, CarImage entity)
        {
            IResult result = BusinessRules.Run(CheckIfFileTypeUnsupported(formFile),
                CheckIfPathExist(entity)
                );
            if (result != null)
            {
                return result;
            }
            var oldRef = _carImageDal.Get(c => c.ImageId == entity.ImageId);
            entity.ImagePath = FileHelper.Update(oldRef.ImagePath, formFile);
            entity.ImageDate = DateTime.Now;
            _carImageDal.Update(entity);
            return new SuccessResult();

        }
        [SecuredOperation("car.delete,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage entity)
        {
            IResult result = BusinessRules.Run(CheckIfPathExist(entity));
            if (result != null)
            {
                return result;
            }
            FileHelper.Delete(entity.ImagePath);
            _carImageDal.Delete(entity);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<CarImage> Get(int Id)
        {
            var result = _carImageDal.Get(c => c.ImageId == Id);
            return new SuccessDataResult<CarImage>(result);
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAllByCarId(int id)
        {

            return new SuccessDataResult<List<CarImage>>(CheckIfCarHaveNoImage(id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result,Messages.EntitiesListed);
        }




        private IResult CheckIfPathExist(CarImage carImage)
        {
            var result = _carImageDal.Get(c => c.ImagePath == carImage.ImagePath && c.CarId == carImage.CarId);
            if (result == null)
            {
                return new ErrorResult(Messages.CheckIdOrPath);
            }
            return new SuccessResult();

        }

        private IResult CheckIfCarImageLimitIsExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result <= 5)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarImageLimitExceeded);
        }
        private IResult CheckIfFileTypeUnsupported(IFormFile formFile)
        {
            string[] array = new string[] { ".jpg", ".jpeg", ".png",".jfif" };
            string fileType = formFile.FileName.ToString().ToLower();
            foreach (var ar in array)
            {
                if (fileType.Contains(ar))
                {
                    return new SuccessResult();
                }

            }
            return new ErrorResult(Messages.UnsupportedMediaType);
        }
        private List<CarImage> CheckIfCarHaveNoImage(int carId)
        {
            string path = Environment.CurrentDirectory + @"\wwwroot\images\defaultPhoto.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count == 0)
            {
                return new List<CarImage>{ new CarImage  { CarId = carId, ImagePath = path, ImageDate = DateTime.Now }};

            }
            return result;
        }

        public void SetDefaultImage(int carId)
        {
            string path = Environment.CurrentDirectory + @"\wwwroot\images\defaultPhoto.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count == 0)
            {
                _carImageDal.Add(new CarImage { CarId = carId, ImagePath = path, ImageDate = DateTime.Now });
            }
        }
    }
}
