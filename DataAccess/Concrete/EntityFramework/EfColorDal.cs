using Core.DataAccess.EntityFramework;
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
                var product = context.Colors.SingleOrDefault(c => c.Id == colorId);
                if (product != null)
                {
                    context.Colors.Remove(product);
                    context.SaveChanges();
                }
            }
        }
    }
}
