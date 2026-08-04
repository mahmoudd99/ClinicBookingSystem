using Clinic.Application.Exceptions;
using Clinic.Application.Interfaces.Persistence;
using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Appointments.Commands.ConfirmAppointment
{
    public class ConfirmAppointmentCommandHandler
    : IRequestHandler<ConfirmAppointmentCommand>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public ConfirmAppointmentCommandHandler(
            IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task Handle(
            ConfirmAppointmentCommand request,
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

            appointment.Confirm();

            await _appointmentRepository.UpdateAsync(appointment);
        }
    }
}
