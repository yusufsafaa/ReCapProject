using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

//CarManager carManager = new CarManager(new EfCarDal());
BrandManager brandManager = new BrandManager(new EfBrandDal());

brandManager.Add(new Brand() { Name = "Audi" });
brandManager.Add(new Brand() { Name = "Mercedes" });
brandManager.Add(new Brand() { Name = "Bmw" });
brandManager.Add(new Brand() { Name = "Volvo" });
brandManager.Add(new Brand() { Name = "Hyundai" });
brandManager.Add(new Brand() { Name = "Volkswagen" });



