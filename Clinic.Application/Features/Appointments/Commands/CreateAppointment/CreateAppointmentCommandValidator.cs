using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandValidator
    : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator()
        {
            RuleFor(x => x.DoctorId)
                .GreaterThan(0);

            RuleFor(x => x.PatientId)
                .GreaterThan(0);

            RuleFor(x => x.AppointmentDate)
                .GreaterThan(DateTime.Now)
                .WithMessage("Appointment date must be in the future.");
        }
    }
}
