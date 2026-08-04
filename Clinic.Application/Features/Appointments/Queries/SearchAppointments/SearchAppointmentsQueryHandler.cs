using Clinic.Application.Common.Models;
using Clinic.Application.Features.Appointments.DTOs;
using Clinic.Application.Interfaces.Persistence;
using MediatR;

namespace Clinic.Application.Features.Appointments.Queries.SearchAppointments
{
    public class SearchAppointmentsQueryHandler
        : IRequestHandler<SearchAppointmentsQuery, PagedResponse<DoctorAppointmentDto>>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public SearchAppointmentsQueryHandler(
            IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<PagedResponse<DoctorAppointmentDto>> Handle(
            SearchAppointmentsQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _appointmentRepository.SearchAsync(
                request.DoctorId,
                request.PatientName,
                request.Status,
                request.Date,
                request.PageNumber,
                request.PageSize);

            return new PagedResponse<DoctorAppointmentDto>
            {
                Items = result.Items.Select(a => new DoctorAppointmentDto
                {
                    AppointmentId = a.Id,
                    PatientName = $"{a.Patient.FirstName} {a.Patient.LastName}",
                    AppointmentDate = a.AppointmentDate,
                    Status = a.Status.ToString(),
                    Notes = a.Notes
                }).ToList(),

                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = result.TotalCount
            };
        }
    }
}