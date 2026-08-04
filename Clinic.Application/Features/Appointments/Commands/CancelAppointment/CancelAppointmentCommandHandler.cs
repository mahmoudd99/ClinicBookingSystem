using Clinic.Application.Exceptions;
using Clinic.Application.Interfaces.Persistence;
using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Appointments.Commands.CancelAppointment
{
    public class CancelAppointmentCommandHandler
    : IRequestHandler<CancelAppointmentCommand>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public CancelAppointmentCommandHandler(
            IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task Handle(
            CancelAppointmentCommand request,
            CancellationToken cancellationToken)
        {
            var appointment =
                await _appointmentRepository.GetByIdAsync(request.AppointmentId);

            if (appointment is null)
            {
                throw new NotFoundException(
                    nameof(Appointment),
                    request.AppointmentId);
            }

            appointment.Cancel();

            await _appointmentRepository.UpdateAsync(appointment);
        }
    }
}
