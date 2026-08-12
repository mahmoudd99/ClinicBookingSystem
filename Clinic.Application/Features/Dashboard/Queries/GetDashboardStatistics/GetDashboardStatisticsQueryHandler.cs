using Clinic.Application.Features.Dashboard.DTOs;
using Clinic.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Dashboard.Queries.GetDashboardStatistics
{
    public class GetDashboardStatisticsQueryHandler
        : IRequestHandler<GetDashboardStatisticsQuery, DashboardStatisticsDto>
    {
        private readonly IDashboardRepository _dashboardRepository;

        public GetDashboardStatisticsQueryHandler(
            IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<DashboardStatisticsDto> Handle(
            GetDashboardStatisticsQuery request,
            CancellationToken cancellationToken)
        {
            return await _dashboardRepository.GetStatisticsAsync();
        }
    }
}