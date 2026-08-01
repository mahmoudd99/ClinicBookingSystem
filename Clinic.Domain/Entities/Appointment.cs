using Clinic.Domain.Enums.AppointmentStatus;
using Clinic.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; private set; }

        public int DoctorId { get; private set; }

        public int PatientId { get; private set; }

        public DateTime AppointmentDate { get; private set; }

        public AppointmentStatus Status { get; private set; }

        public string? Notes { get; private set; }

        public Doctor Doctor { get; private set; } = default!;

        public Patient Patient { get; private set; } = default!;

        private Appointment()
        {
        }

        public Appointment(
            int doctorId,
            int patientId,
            DateTime appointmentDate,
            string? notes)
        {
            DoctorId = doctorId;
            PatientId = patientId;
            AppointmentDate = appointmentDate;
            Notes = notes;

            Status = AppointmentStatus.Pending;
        }

        public void Confirm()
        {
            if (Status != AppointmentStatus.Pending)
                throw new BusinessException("Only pending appointments can be confirmed.");

            Status = AppointmentStatus.Confirmed;
        }

        public void Complete()
        {
            if (Status != AppointmentStatus.Confirmed)
                throw new BusinessException("Only confirmed appointments can be completed.");

            Status = AppointmentStatus.Completed;
        }

        public void Cancel()
        {
            if (Status == AppointmentStatus.Completed)
                throw new BusinessException("Completed appointments cannot be cancelled.");

            if (Status == AppointmentStatus.Cancelled)
                throw new BusinessException("Appointment is already cancelled.");

            Status = AppointmentStatus.Cancelled;
        }
    }
}
