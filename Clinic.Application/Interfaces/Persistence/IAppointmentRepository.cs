using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Interfaces.Persistence
{
    public interface IAppointmentRepository
    {
        Task AddAsync(Appointment appointment);

        Task<bool> IsDoctorAvailableAsync(
            int doctorId,
            DateTime appointmentDate);
        Task<List<Appointment>> GetDoctorAppointmentsAsync(int doctorId);

    }
}
