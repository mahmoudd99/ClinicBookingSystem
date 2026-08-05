using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class Prescription
    {
        public int Id { get; private set; }

        public int MedicalRecordId { get; private set; }

        public string MedicationName { get; private set; } = string.Empty;

        public string Dosage { get; private set; } = string.Empty;

        public string Instructions { get; private set; } = string.Empty;

        public MedicalRecord MedicalRecord { get; private set; } = null!;

        private Prescription() { }

        public Prescription(
            int medicalRecordId,
            string medicationName,
            string dosage,
            string instructions)
        {
            MedicalRecordId = medicalRecordId;
            MedicationName = medicationName;
            Dosage = dosage;
            Instructions = instructions;
        }
    }
}