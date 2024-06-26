﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, RentACarContext>, IColorDal
    {
        public void DeleteById(int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var color = context.Colors.SingleOrDefault(c => c.Id == colorId);
                if (color != null)
                {
                    context.Colors.Remove(color);
                    context.SaveChanges();
                }
            }
        }
    }
}
