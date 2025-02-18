using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
        public class GetBrandByIdQureyHandler
        {
            private readonly IRepository<Brand> _repository;

            public GetBrandByIdQureyHandler(IRepository<Brand> repository)
            {
                _repository = repository;
            }

            public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
            {
                var values = await _repository.GetByIdAsync(query.Id);
                return new GetBrandByIdQueryResult
                {
                    BrandID = values.BrandID,
                    Name = values.Name
                };
            }
        }
}
