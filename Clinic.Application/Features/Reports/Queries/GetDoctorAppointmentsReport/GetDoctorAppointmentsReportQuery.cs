using Clinic.Application.Features.Reports.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Reports.Queries.GetDoctorAppointmentsReport
{
    public class GetDoctorAppointmentsReportQuery
        : IRequest<List<DoctorAppointmentReportDto>>
    {
        public int DoctorId { get; set; }
    }
}
