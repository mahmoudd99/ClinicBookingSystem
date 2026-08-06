using Clinic.Application.Features.MedicalRecords.Queries.GetPatientHistory;
using Clinic.Application.Features.MedicalRecords.Commands.CreateMedicalRecord;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IMediator _mediator;
            
        public MedicalRecordsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMedicalRecordCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetPatientHistory(int patientId)
        {
            var result = await _mediator.Send(
                new GetPatientHistoryQuery
                {
                    PatientId = patientId
                });

            return Ok(result);
        }
    }
}