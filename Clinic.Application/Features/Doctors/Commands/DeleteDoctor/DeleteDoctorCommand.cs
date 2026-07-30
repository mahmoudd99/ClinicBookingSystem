using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Doctors.Commands.DeleteDoctor
{
    public class DeleteDoctorCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
