using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Appointments.Commands.CompleteAppointment
{
    public class CompleteAppointmentCommand : IRequest
    {
        public int AppointmentId { get; }

        public CompleteAppointmentCommand(int appointmentId)
        {
            AppointmentId = appointmentId;
        }
    }
}
