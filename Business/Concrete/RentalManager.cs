using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate == null) 
            {
                return new ErrorResult(Messages.InvalidRental);
            }

            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IDataResult<bool> CheckIfCarCanBeRented(int carId, DateTime rentDate, DateTime returnDate)
        {
            var rentals = _rentalDal.GetAll(r => r.CarId == carId && r.DeliveryStatus==false);

            if(rentals.Count==0)
            {
                return new SuccessDataResult<bool>(true);
            }

            foreach (var rental in rentals)
            {
                if ((rental.RentDate<=rentDate && rental.ReturnDate>=rentDate) || (rental.RentDate<=returnDate && rental.ReturnDate>=returnDate) )
                {
                    return new ErrorDataResult<bool>(false,Messages.CarIsNotSuitableOnSelectedDate);
                }
            }

            return new SuccessDataResult<bool>(true);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
