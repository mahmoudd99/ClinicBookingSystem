using Clinic.Application.Features.MedicalRecords.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.MedicalRecords.Queries.GetPatientHistory
{
    public class GetPatientHistoryQuery : IRequest<List<MedicalRecordDto>>
    {
        public int PatientId { get; set; }
    }
}
