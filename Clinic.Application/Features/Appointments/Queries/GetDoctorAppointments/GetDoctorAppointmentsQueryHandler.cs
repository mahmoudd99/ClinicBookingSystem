using Clinic.Application.Features.Appointments.DTOs;
using Clinic.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Appointments.Queries.GetDoctorAppointments
{
    public class GetDoctorAppointmentsQueryHandler
    : IRequestHandler<GetDoctorAppointmentsQuery, List<DoctorAppointmentDto>>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetDoctorAppointmentsQueryHandler(
            IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<DoctorAppointmentDto>> Handle(
            GetDoctorAppointmentsQuery request,
            CancellationToken cancellationToken)
        {
            var appointments = await _appointmentRepository
                .GetDoctorAppointmentsAsync(request.DoctorId);

            return appointments.Select(a => new DoctorAppointmentDto
            {
                AppointmentId = a.Id,
                PatientName = $"{a.Patient.FirstName} {a.Patient.LastName}",
                AppointmentDate = a.AppointmentDate,
                Status = a.Status.ToString(),
                Notes = a.Notes
            }).ToList();
        }
    }
}
