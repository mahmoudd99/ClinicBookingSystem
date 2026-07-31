using Clinic.Application.Features.Doctors.Commands.CreateDoctor;
using Clinic.Application.Features.Doctors.Commands.DeleteDoctor;
using Clinic.Application.Features.Doctors.Commands.UpdateDoctor;
using Clinic.Application.Features.Doctors.Queries.GetAllDoctors;
using Clinic.Application.Features.Doctors.Queries.GetDoctorById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
   
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDoctorCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllDoctorsQuery());

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetDoctorByIdQuery
            {
                Id = id
            });

            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateDoctorCommand command)
        {
            command.Id = id;

            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteDoctorCommand
            {
                Id = id
            });

            return Ok(result);
        }



    }
    }
