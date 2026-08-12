using Clinic.Application.Exceptions;
using Clinic.Application.Interfaces.Persistence;
using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Appointments.Commands.CompleteAppointment
{

    public class CompleteAppointmentCommandHandler
        : IRequestHandler<CompleteAppointmentCommand>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public CompleteAppointmentCommandHandler(
            IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task Handle(
            CompleteAppointmentCommand request,
            CancellationToken cancellationToken)
        {
            var appointment =
                await _appointmentRepository.GetByIdAsync(
                    request.AppointmentId);

            if (appointment is null)
            {
                throw new NotFoundException(
                    nameof(Appointment),
                    request.AppointmentId);
            }

            appointment.Complete();

            await _appointmentRepository.UpdateAsync(appointment);
        }
    }
}
