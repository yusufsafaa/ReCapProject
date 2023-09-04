using Core.DataAccess.EntityFramework;
using Core.Entities;
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
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
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
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
