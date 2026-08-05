using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Prescriptions.Commands.AddPrescription
{
    public class AddPrescriptionCommandValidator
        : AbstractValidator<AddPrescriptionCommand>
    {
        public AddPrescriptionCommandValidator()
        {
            RuleFor(x => x.MedicalRecordId)
                .GreaterThan(0);

            RuleFor(x => x.MedicationName)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Dosage)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Instructions)
                .MaximumLength(500);
        }
    }


}
