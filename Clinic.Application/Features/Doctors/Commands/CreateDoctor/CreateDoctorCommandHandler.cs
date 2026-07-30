using AutoMapper;
using Clinic.Application.Interfaces.Persistence;
using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, int>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public CreateDoctorCommandHandler(IDoctorRepository doctorRepository , IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateDoctorCommand request,CancellationToken cancellationToken)
        {
            //var doctor = new Doctor(
                
            //    request.FirstName,
            //    request.LastName,
            //    request.Email,
            //    request.PhoneNumber,
            //    request.SpecializationId
            //);
            var doctor = _mapper.Map<Doctor>(request);

            await _doctorRepository.AddAsync(doctor);

            return doctor.Id;
         
       
        

    }
    }
}
