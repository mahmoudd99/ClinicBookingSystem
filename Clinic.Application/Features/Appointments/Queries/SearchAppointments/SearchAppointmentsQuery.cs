using Clinic.Application.Features.Appointments.DTOs;
using Clinic.Domain.Enums.AppointmentStatus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Appointments.Queries.SearchAppointments
{
    using Clinic.Application.Common.Models;

    public class SearchAppointmentsQuery : IRequest<PagedResponse<DoctorAppointmentDto>>
    {
        public int? DoctorId { get; set; }

        public string? PatientName { get; set; }

        public AppointmentStatus? Status { get; set; }

        public DateTime? Date { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
