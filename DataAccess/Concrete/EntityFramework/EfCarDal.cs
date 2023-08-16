using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join col in context.Colors
                             on c.ColorId equals col.Id
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandId = b.Id,
                                 ColorId = col.Id,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 BrandName = b.Name,
                                 CarModel = c.CarModel,
                                 ColorName = col.Name,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = (from ci in context.CarImages where ci.CarId == c.Id select ci.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            using (CarRentalContext context=new())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join col in context.Colors
                             on c.ColorId equals col.Id
                             where b.Id == brandId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandId = b.Id,
                                 ColorId = col.Id,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 BrandName = b.Name,
                                 CarModel = c.CarModel,
                                 ColorName = col.Name,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = (from ci in context.CarImages where ci.CarId == c.Id select ci.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            using (CarRentalContext context = new())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join col in context.Colors
                             on c.ColorId equals col.Id
                             where col.Id == colorId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandId = b.Id,
                                 ColorId = col.Id,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 BrandName = b.Name,
                                 CarModel = c.CarModel,
                                 ColorName = col.Name,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = (from ci in context.CarImages where ci.CarId == c.Id select ci.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailByCarId(int carId)
        {
            using (CarRentalContext context = new())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join col in context.Colors
                             on c.ColorId equals col.Id
                             where c.Id == carId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandId = b.Id,
                                 ColorId = col.Id,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 BrandName = b.Name,
                                 CarModel = c.CarModel,
                                 ColorName = col.Name,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = (from ci in context.CarImages where ci.CarId == c.Id select ci.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }
    }
}
