using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.MedicalRecords.Commands.CreateMedicalRecord
{
    public class CreateMedicalRecordCommandValidator
        : AbstractValidator<CreateMedicalRecordCommand>
    {
        public CreateMedicalRecordCommandValidator()
        {
            RuleFor(x => x.PatientId)
                .GreaterThan(0);

            RuleFor(x => x.DoctorId)
                .GreaterThan(0);

            RuleFor(x => x.VisitDate)
                .NotEmpty();

            RuleFor(x => x.Diagnosis)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Notes)
                .MaximumLength(1000);
        }
    }
}
