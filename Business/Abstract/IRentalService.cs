﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);
        IResult Add(Rental rental);
        IResult Complete(int rentalId);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}
