using Clinic.Application.Features.Reports.Queries.GetDoctorAppointmentsReport;
using Clinic.Application.Features.Reports.Queries.GetNewPatientsReport;
using Clinic.Application.Features.Reports.Queries.GetTopDoctorsReport;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("doctor/{doctorId}/appointments")]
        public async Task<IActionResult> GetDoctorAppointmentsReport(
            int doctorId)
        {
            var result = await _mediator.Send(
                new GetDoctorAppointmentsReportQuery
                {
                    DoctorId = doctorId
                });

            return Ok(result);
        }

        [HttpGet("new-patients")]
        public async Task<IActionResult> GetNewPatientsReport(
            [FromQuery] int days = 30)
        {
            var result = await _mediator.Send(
                new GetNewPatientsReportQuery
                {
                    Days = days
                });

            return Ok(result);
        }
        [HttpGet("top-doctors")]
        public async Task<IActionResult> GetTopDoctorsReport()
        {
            var result = await _mediator.Send(
                new GetTopDoctorsReportQuery());

            return Ok(result);
        }
    }
}
