using AutoMapper;
using Clinic.Application.Features.Doctors.Commands.CreateDoctor;
using Clinic.Application.Interfaces.Persistence;
using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Patients.Commands.CreatePatient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, int>
    {
        
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public CreatePatientCommandHandler(IPatientRepository patientRepository , IMapper mapper)
        {
            
            _patientRepository = patientRepository;
            _mapper = mapper;
        }
        

        public async Task<int> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = _mapper.Map<Patient>(request);

            await _patientRepository.AddAsync(patient);

            return patient.Id;
        }
    }
}
