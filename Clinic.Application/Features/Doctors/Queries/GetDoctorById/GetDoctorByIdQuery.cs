using Clinic.Application.Features.Doctors.Queries.GetAllDoctors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Doctors.Queries.GetDoctorById
{

    public class GetDoctorByIdQuery : IRequest<DoctorDto>
    {
        public int Id { get; set; }
    }
}
