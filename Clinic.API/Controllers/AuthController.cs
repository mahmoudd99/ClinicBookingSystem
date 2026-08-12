using Clinic.Application.Features.Auth.Commands.Login;
using Clinic.Application.Features.Auth.Commands.RefreshToken;
using Clinic.Application.Features.Auth.Commands.Register;
using Clinic.Application.Features.Auth.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _mediator.Send(new RegisterCommand
            {
                Request = request
            });

            return Ok(result);
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _mediator.Send(new LoginCommand
            {
                Request = request
            });

            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(
        RefreshTokenCommand command)
            {
                var result = await _mediator.Send(command);

                return Ok(result);
            }



    }
}
