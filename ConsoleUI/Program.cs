using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

CarManager carManager = new CarManager(new EfCarDal());
ColorManager colorManager = new ColorManager(new EfColorDal());

//foreach (var car in carManager.GetCarDetails())
//{
//    Console.WriteLine("{0} {1} {2} {3}",car.BrandName,car.CarModel,car.ColorName,car.DailyPrice);
//}


