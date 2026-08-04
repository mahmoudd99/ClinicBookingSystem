using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Appointments.Commands.CancelAppointment
{
    public class CancelAppointmentCommand : IRequest
    {
        public int AppointmentId { get; set; }

        public CancelAppointmentCommand(int appointmentId)
        {
            AppointmentId = appointmentId;
        }
    }
}
