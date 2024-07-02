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

            rental.ReturnDate = null;
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Complete(int rentalId)
        {
            IResult result = BusinessRules.Run(IsRentalCompleted(rentalId));
            if (result != null)
            {
                return result;
            }

            Rental rental = _rentalDal.Get(r => r.Id == rentalId);

            rental.ReturnDate = DateTime.Now;
            _rentalDal.Update(rental);
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

        public IResult Update(Rental rental)
        {
            IResult result = BusinessRules.Run(IsDateValid(rental.RentDate));
            if (result != null)
            {
                return result;
            }

            _rentalDal.Update(rental);
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

        private IResult IsRentalCompleted(int rentalId)
        {
            Rental rental = _rentalDal.Get(r => r.Id == rentalId);
            if (rental.ReturnDate != null)
            {
                return new ErrorResult(Messages.RentalAlreadyCompleted);
            }
            return new SuccessResult();
        }
    }
}
