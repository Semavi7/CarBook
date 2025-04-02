using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterface;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandByIdQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarWithBrandByIdQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public GetCarWithBrandByIdQueryResult Handle(GetCarWithBrandByIdQuery query)
        {
            var values = _carRepository.GetCarWithBrand(query.Id);
            return new GetCarWithBrandByIdQueryResult 
            {
                CarID = values.CarID,
                BrandID = values.BrandID,
                BrandName = values.Brand.Name,
                BigImageUrl = values.BigImageUrl,
                CoverImageUrl = values.CoverImageUrl,
                Fuel = values.Fuel,
                Transmission = values.Transmission,
                Seat = values.Seat,
                Model = values.Model,
                Km = values.Km,
                Luggage = values.Luggage
            };
        }
    }
}
