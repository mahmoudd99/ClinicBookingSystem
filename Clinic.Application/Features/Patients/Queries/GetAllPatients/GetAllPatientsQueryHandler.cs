using AutoMapper;
using Clinic.Application.Features.Patients.DTOS;
using Clinic.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Patients.Queries.GetAllPatients
{
    public class GetAllPatientsQueryHandler
    : IRequestHandler<GetAllPatientsQuery, List<PatientDto>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public GetAllPatientsQueryHandler(
            IPatientRepository patientRepository,
            IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<List<PatientDto>> Handle(
            GetAllPatientsQuery request,
            CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetAllAsync();

            return _mapper.Map<List<PatientDto>>(patients);
        }
    }
}
