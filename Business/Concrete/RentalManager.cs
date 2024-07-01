using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(IsDateValid(rental.RentDate));
            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Complete(int rentalId)
        {
            Rental rentalToComplete = _rentalDal.Get(r => r.Id == rentalId);
            if (rentalToComplete.ReturnDate == null)
            {
                return new ErrorResult(Messages.RentalAlreadyCompleted);
            }
            rentalToComplete.ReturnDate = null;
            _rentalDal.Update(rentalToComplete);

            return new SuccessResult(Messages.RentalCompleted);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsFetched);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId), Messages.RentalFetched);
        }

        public IResult UpdateRentDate(int rentalId, long updateTime)
        {
            DateTime dateToUpdate = DateTimeOffset.FromUnixTimeSeconds(updateTime).UtcDateTime;

            IResult result = BusinessRules.Run(IsDateValid(dateToUpdate));
            if (result != null)
            {
                return result;
            }

            Rental rentalToUpdate = _rentalDal.Get(r => r.Id == rentalId);
            rentalToUpdate.ReturnDate = dateToUpdate;
            _rentalDal.Update(rentalToUpdate);
            return new SuccessResult(Messages.RentalUpdated);
        }

        private IResult IsDateValid(DateTime dateToUpdate)
        {
            DateTime currentTime = DateTime.UtcNow;
            if (dateToUpdate < currentTime)
            {
                return new ErrorResult(Messages.InvalidTime);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarAvailableForRent(int rentalId)
        {
            Rental completedRental = _rentalDal.Get(r => r.Id == rentalId);
            if (completedRental.ReturnDate == null)
            {
                return new ErrorResult(Messages.RentalAlreadyCompleted);
            }
            completedRental.ReturnDate = null;
            return new SuccessResult();
        }
    }
}
