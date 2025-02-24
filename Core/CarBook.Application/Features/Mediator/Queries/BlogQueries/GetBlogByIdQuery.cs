﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogByIdQuery : IRequest<GetBlogByIdQueryResult>
    {
        public int Id { get; set; }

        public GetBlogByIdQuery(int id)
        {
            Id = id;
        }
    }
}
