using Clinic.Application.Features.Doctors.Commands.CreateDoctor;
using Clinic.Application.Features.Patients.Commands.CreatePatient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class PatientsController : ControllerBase
        {
            private readonly IMediator _mediator;

            public PatientsController(IMediator mediator)
            {
                _mediator = mediator;
            }



        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }







    }
}
