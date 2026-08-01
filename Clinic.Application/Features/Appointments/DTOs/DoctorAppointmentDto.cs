using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Appointments.DTOs
{
    public class DoctorAppointmentDto
    {
        public int AppointmentId { get; set; }

        public string PatientName { get; set; } = string.Empty;

        public DateTime AppointmentDate { get; set; }

        public string Status { get; set; } = string.Empty;

        public string? Notes { get; set; }
    }
}
