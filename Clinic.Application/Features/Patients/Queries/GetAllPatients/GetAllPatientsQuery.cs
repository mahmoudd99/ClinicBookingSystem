using Clinic.Application.Features.Patients.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Patients.Queries.GetAllPatients
{
    public class GetAllPatientsQuery : IRequest<List<PatientDto>>
    {
    }
}
