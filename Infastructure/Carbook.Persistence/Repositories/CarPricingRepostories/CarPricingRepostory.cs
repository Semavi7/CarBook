using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carbook.Persistence.Context;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carbook.Persistence.Repositories.CarPricingRepostories
{
    public class CarPricingRepostory : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepostory(CarBookContext context)
        {
            _context = context;
        }


        public List<CarPricing> GetCarPrincingWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingID == 3).ToList();
            return values;
        }
    }
}
