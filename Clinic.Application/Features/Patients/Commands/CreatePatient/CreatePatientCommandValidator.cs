using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Patients.Commands.CreatePatient
{
    public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientCommandValidator()
        {


            RuleFor(x => x.FirstName).NotEmpty();

            RuleFor(x => x.LastName).NotEmpty();

            RuleFor(x => x.NationalId).NotEmpty();

            RuleFor(x => x.PhoneNumber).NotEmpty();

            RuleFor(x => x.Address).NotEmpty();

            RuleFor(x => x.DateOfBirth)
        .LessThan(DateTime.Today);
        }

    }
}