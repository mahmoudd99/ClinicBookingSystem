using Clinic.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Doctors.Queries.GetAllDoctors
{
    public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, List<DoctorDto>>
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetAllDoctorsQueryHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<List<DoctorDto>> Handle( GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.GetAllAsync();

            var result = doctors.Select(d => new DoctorDto
            {
                Id = d.Id,
                FullName = $"{d.FirstName} {d.LastName}",
                Email = d.Email,
                PhoneNumber = d.PhoneNumber
            }).ToList();

            return result;
        }
    }
}
