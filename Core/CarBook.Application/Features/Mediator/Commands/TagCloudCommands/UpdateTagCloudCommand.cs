﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class UpdateTagCloudCommand : IRequest
    {
        public int TagCloudId { get; set; }
        public string Title { get; set; }
        public int BlogID { get; set; }
    }
}
