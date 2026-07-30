using AutoMapper;
using Clinic.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Doctors.Commands.UpdateDoctor
{
 public class UpdateDoctorCommandHandler: IRequestHandler<UpdateDoctorCommand, bool>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public UpdateDoctorCommandHandler(IDoctorRepository doctorRepository , IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetByIdAsync(request.Id);

            if (doctor is null)
            {
                throw new Exception("Doctor Not Found");
            }

            _mapper.Map(request, doctor);
            //doctor.Update(
            //    request.FirstName,
            //    request.LastName,
            //    request.Email,
            //    request.PhoneNumber,
            //    request.SpecializationId);

            await _doctorRepository.UpdateAsync(doctor);

            return true;
        }
    }
}
