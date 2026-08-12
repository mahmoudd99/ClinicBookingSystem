using Clinic.Application.Features.Dashboard.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Dashboard.Queries.GetDashboardStatistics
{
    public class GetDashboardStatisticsQuery
    : IRequest<DashboardStatisticsDto>
    {
    }

}
