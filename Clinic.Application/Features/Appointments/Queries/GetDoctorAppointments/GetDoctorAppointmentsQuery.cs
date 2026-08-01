using Clinic.Application.Features.Appointments.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Appointments.Queries.GetDoctorAppointments
{
    public class GetDoctorAppointmentsQuery
    : IRequest<List<DoctorAppointmentDto>>
    {
        public int DoctorId { get; set; }

        public GetDoctorAppointmentsQuery(int doctorId)
        {
            DoctorId = doctorId;
        }
    }
}
