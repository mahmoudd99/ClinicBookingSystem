using Clinic.Application.Features.Doctors.Queries.GetAllDoctors;
using Clinic.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Doctors.Queries.GetDoctorById
{
    public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, DoctorDto>
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetDoctorByIdQueryHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<DoctorDto> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetByIdAsync(request.Id);

            if (doctor is null)
            {
                throw new Exception("Doctor Not Found");
            }

            return new DoctorDto
            {
                Id = doctor.Id,
                FullName = $"{doctor.FirstName} {doctor.LastName}",
                Email = doctor.Email,
                PhoneNumber = doctor.PhoneNumber
            };
        }
    }
}
