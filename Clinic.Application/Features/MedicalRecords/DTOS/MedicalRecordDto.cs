using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.MedicalRecords.DTOS
{
    public class MedicalRecordDto
    {
        public DateTime VisitDate { get; set; }

        public string DoctorName { get; set; } = string.Empty;

        public string Diagnosis { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;

        public List<PrescriptionDto> Prescriptions { get; set; } = new();
    }
}
