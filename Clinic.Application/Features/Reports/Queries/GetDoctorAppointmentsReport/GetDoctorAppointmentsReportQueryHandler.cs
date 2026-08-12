using Clinic.Application.Features.Reports.DTOs;
using Clinic.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Reports.Queries.GetDoctorAppointmentsReport
{
    public class GetDoctorAppointmentsReportQueryHandler
         : IRequestHandler<
             GetDoctorAppointmentsReportQuery,
             List<DoctorAppointmentReportDto>>
    {
        private readonly IReportsRepository _reportsRepository;

        public GetDoctorAppointmentsReportQueryHandler(
            IReportsRepository reportsRepository)
        {
            _reportsRepository = reportsRepository;
        }

        public async Task<List<DoctorAppointmentReportDto>> Handle(
            GetDoctorAppointmentsReportQuery request,
            CancellationToken cancellationToken)
        {
            return await _reportsRepository
                .GetDoctorAppointmentsReportAsync(request.DoctorId);
        }
    }
}
