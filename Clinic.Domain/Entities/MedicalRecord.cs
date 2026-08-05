using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class MedicalRecord
    {
        public int Id { get; private set; }

        public int PatientId { get; private set; }

        public int DoctorId { get; private set; }

        public DateTime VisitDate { get; private set; }

        public string Diagnosis { get; private set; } = string.Empty;

        public string Notes { get; private set; } = string.Empty;

        public DateTime CreatedAt { get; private set; }

        public Patient Patient { get; private set; } = null!;

        public Doctor Doctor { get; private set; } = null!;

        public ICollection<Prescription> Prescriptions { get; private set; }
            = new List<Prescription>();

        public void AddPrescription(
                 string medicationName,
                 string dosage,
                 string instructions)
                {
            Prescriptions.Add(
                new Prescription(
                    Id,
                    medicationName,
                    dosage,
                    instructions));
        }
        private MedicalRecord() { }

        public MedicalRecord(
            int patientId,
            int doctorId,
            DateTime visitDate,
            string diagnosis,
            string notes)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            VisitDate = visitDate;
            Diagnosis = diagnosis;
            Notes = notes;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
