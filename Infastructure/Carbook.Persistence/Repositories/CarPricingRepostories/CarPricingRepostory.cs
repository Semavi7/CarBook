using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carbook.Persistence.Context;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
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

        public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From (Select Model,PricingID,Amount From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarID Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([3],[4],[5])) as PivotTable;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel();
                        Enumerable.Range(1, 3).ToList().ForEach(x =>
                        {
                            carPricingViewModel.Model = reader[0].ToString();
                            if (DBNull.Value.Equals(reader[x]))
                            {
                                carPricingViewModel.Amounts.Add(0);
                            }
                            else
                            {
                                carPricingViewModel.Amounts.Add(reader.GetDecimal(x));
                            }
                        });
                        values.Add(carPricingViewModel);
                    }
                }
                _context.Database.CloseConnection();
                return values;
            }
        }

        public List<CarPricing> GetCarPrincingWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingID == 3).ToList();
            return values;
        }

        List<CarPricing> ICarPricingRepository.GetCarPricingWithTimePeriod()
        {
            throw new NotImplementedException();
        }
    }
}
