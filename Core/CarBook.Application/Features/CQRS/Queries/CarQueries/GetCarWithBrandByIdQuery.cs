using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarWithBrandByIdQuery
    {
        public int Id { get; set; }

        public GetCarWithBrandByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
