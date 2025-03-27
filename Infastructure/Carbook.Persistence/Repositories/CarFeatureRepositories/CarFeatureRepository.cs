using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carbook.Persistence.Context;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carbook.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public void ChangeCarFeatureAvailableToFalse(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefault();
            values.Availabe = false;
            _context.SaveChanges();
        }

        public void ChangeCarFeatureAvailableToTrue(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefault();
            values.Availabe = true;
            _context.SaveChanges();
        }

        public async Task CreateCarFeatureByCar(CarFeature carFeature)
        {
            var values = await _context.CarFeatures.Where(x => x.CarID == carFeature.CarID && x.FeatureID == carFeature.FeatureID).FirstOrDefaultAsync();
            if (values is null)
            {
                await _context.CarFeatures.AddAsync(carFeature);
                await _context.SaveChangesAsync();
            }
        }

        public List<CarFeature> GetCarFeatureByCarID(int carID)
        {
            var values = _context.CarFeatures.Include(y => y.Feature).Where(x => x.CarID == carID).ToList();
            return values;
        }
    }
}
