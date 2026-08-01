using AutoMapper;
using Clinic.Application.Features.Appointments.Commands.CreateAppointment;
using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Mappings;

public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<CreateAppointmentCommand, Appointment>();
    }
}