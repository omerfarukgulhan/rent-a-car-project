using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IColorService colorService = new ColorManager(new EfColorDal());

            var colors = colorService.GetAll();

            foreach (var color in colors.Data)
            {
                Console.WriteLine(color.Name);
            }
        }
    }
}
