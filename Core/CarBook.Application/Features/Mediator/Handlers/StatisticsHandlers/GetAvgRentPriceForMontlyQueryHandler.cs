using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAvgRentPriceForMontlyQueryHandler : IRequestHandler<GetAvgRentPriceForMontlyQuery, GetAvgRentPriceForMonthlyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgRentPriceForMontlyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgRentPriceForMonthlyQueryResult> Handle(GetAvgRentPriceForMontlyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvgRentPriceForMontly();
            return new GetAvgRentPriceForMonthlyQueryResult
            {
                AvgRentPriceForMonthly = value
            };
        }
    }
}
