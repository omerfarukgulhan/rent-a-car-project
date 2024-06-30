using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, RentACarContext>, IBrandDal
    {
        public void DeleteById(int brandId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var brand = context.Brands.SingleOrDefault(b => b.Id == brandId);
                if (brand != null)
                {
                    context.Brands.Remove(brand);
                    context.SaveChanges();
                }
            }
        }
    }
}
