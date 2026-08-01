using AutoMapper;
using Clinic.Application.Features.Doctors.Commands.CreateDoctor;
using Clinic.Application.Features.Patients.Commands.CreatePatient;
using Clinic.Application.Features.Patients.DTOS;
using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Mappings
{
    public class PatientProfile: Profile
    {
        public PatientProfile()
        {
            
            CreateMap<CreatePatientCommand, Patient>();

            CreateMap<Patient, PatientDto>();
        }
    }
}
