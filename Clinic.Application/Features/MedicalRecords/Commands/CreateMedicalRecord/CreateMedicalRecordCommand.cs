using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.MedicalRecords.Commands.CreateMedicalRecord { 
    public class CreateMedicalRecordCommand : IRequest<int>
    {
        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime VisitDate { get; set; }

        public string Diagnosis { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;
    }
}
