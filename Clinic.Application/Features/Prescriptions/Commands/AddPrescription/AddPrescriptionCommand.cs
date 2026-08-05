using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Prescriptions.Commands.AddPrescription
{

    public class AddPrescriptionCommand : IRequest<int>
    {
        public int MedicalRecordId { get; set; }

        public string MedicationName { get; set; } = string.Empty;

        public string Dosage { get; set; } = string.Empty;

        public string Instructions { get; set; } = string.Empty;
    }



}
