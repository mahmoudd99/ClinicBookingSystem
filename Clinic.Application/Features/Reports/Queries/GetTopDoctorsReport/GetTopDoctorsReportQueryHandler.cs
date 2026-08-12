using Clinic.Application.Features.Reports.DTOs;
using Clinic.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Reports.Queries.GetTopDoctorsReport
{
    public class GetTopDoctorsReportQueryHandler
        : IRequestHandler<
            GetTopDoctorsReportQuery,
            List<TopDoctorReportDto>>
    {
        private readonly IReportsRepository _reportsRepository;

        public GetTopDoctorsReportQueryHandler(
            IReportsRepository reportsRepository)
        {
            _reportsRepository = reportsRepository;
        }

        public async Task<List<TopDoctorReportDto>> Handle(
            GetTopDoctorsReportQuery request,
            CancellationToken cancellationToken)
        {
            return await _reportsRepository
                .GetTopDoctorsReportAsync();
        }
    }
}