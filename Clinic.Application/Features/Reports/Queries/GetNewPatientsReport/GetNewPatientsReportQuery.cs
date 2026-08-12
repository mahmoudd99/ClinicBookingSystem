using Clinic.Application.Features.Reports.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Reports.Queries.GetNewPatientsReport
{
    public class GetNewPatientsReportQuery
        : IRequest<List<NewPatientReportDto>>
    {
        public int Days { get; set; } = 30;
    }
}
