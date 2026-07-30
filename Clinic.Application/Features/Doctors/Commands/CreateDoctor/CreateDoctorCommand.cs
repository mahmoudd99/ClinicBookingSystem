using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace Clinic.Application.Features.Doctors.Commands.CreateDoctor;

    public sealed class CreateDoctorCommand : IRequest<int>
    {
        public string FirstName { get; init; } = string.Empty;

        public string LastName { get; init; } = string.Empty;

        public string Email { get; init; } = string.Empty;

        public string PhoneNumber { get; init; } = string.Empty;

        public int SpecializationId { get; init; }
    }

