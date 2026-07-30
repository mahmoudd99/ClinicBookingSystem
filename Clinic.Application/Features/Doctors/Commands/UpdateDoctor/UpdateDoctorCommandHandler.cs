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

        public UpdateDoctorCommandHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<bool> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetByIdAsync(request.Id);

            if (doctor is null)
            {
                throw new Exception("Doctor Not Found");
            }

            doctor.Update(
                request.FirstName,
                request.LastName,
                request.Email,
                request.PhoneNumber,
                request.SpecializationId);

            await _doctorRepository.UpdateAsync(doctor);

            return true;
        }
    }
}
