using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Appointments.Commands.ConfirmAppointment
{
    public class ConfirmAppointmentCommand : IRequest
    {
        public int AppointmentId { get; }

        public ConfirmAppointmentCommand(int appointmentId)
        {
            AppointmentId = appointmentId;
        }
    }
}
