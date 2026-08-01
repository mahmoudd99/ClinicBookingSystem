using Clinic.Application.Features.Appointments.Commands.CreateAppointment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }
    }
}
