using Clinic.Application.Features.Reports.DTOs;
using Clinic.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Reports.Queries.GetNewPatientsReport
{

    public class GetNewPatientsReportQueryHandler
       : IRequestHandler<GetNewPatientsReportQuery,List<NewPatientReportDto>>
    {
        private readonly IReportsRepository _reportsRepository;

        public GetNewPatientsReportQueryHandler(
            IReportsRepository reportsRepository)
        {
            _reportsRepository = reportsRepository;
        }

        public async Task<List<NewPatientReportDto>> Handle(
            GetNewPatientsReportQuery request,
            CancellationToken cancellationToken)
        {
            return await _reportsRepository
                .GetNewPatientsReportAsync(request.Days);
        }
    }
}
