﻿using CarBook.Application.Features.Mediator.Commands.ResevationCommands;
using CarBook.Application.Features.Mediator.Handlers.ReservationHandlers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateResevation(CreateReservationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Rezervasyon Başarıyla Eklendi");
        }
    }
}
