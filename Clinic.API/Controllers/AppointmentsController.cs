using Clinic.Application.Features.Appointments.Commands.CancelAppointment;
using Clinic.Application.Features.Appointments.Commands.ConfirmAppointment;
using Clinic.Application.Features.Appointments.Commands.CreateAppointment;
using Clinic.Application.Features.Appointments.Queries.SearchAppointments;
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
        
        [HttpPut("{id}/confirm")]
        public async Task<IActionResult> Confirm(int id)
        {
            await _mediator.Send(
                new ConfirmAppointmentCommand(id));

            return NoContent();
        }
        
        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> Cancel(int id)
        {
            await _mediator.Send(
                new CancelAppointmentCommand(id));

            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchAppointmentsQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }



    }
}
