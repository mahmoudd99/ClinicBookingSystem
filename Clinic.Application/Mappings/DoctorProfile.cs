using AutoMapper;
using Clinic.Application.Features.Doctors.Commands.CreateDoctor;
using Clinic.Application.Features.Doctors.Commands.UpdateDoctor;
using Clinic.Application.Features.Doctors.Queries.GetAllDoctors;
using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clinic.Application.Mappings
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorDto>();

            CreateMap<CreateDoctorCommand, Doctor>();

            CreateMap<UpdateDoctorCommand, Doctor>();
        }
    }
}
