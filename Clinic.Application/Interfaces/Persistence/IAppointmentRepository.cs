using Clinic.Domain.Entities;
using Clinic.Domain.Enums.AppointmentStatus;
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

        Task<bool> IsDoctorAvailableAsync(int doctorId, DateTime appointmentDate);
Task<List<Appointment>> GetDoctorAppointmentsAsync(int doctorId);
        Task<Appointment?> GetByIdAsync(int id);

        Task UpdateAsync(Appointment appointment);

      Task<(List<Appointment> Items, int TotalCount)> SearchAsync(
                int? doctorId,
                string? patientName,
                AppointmentStatus? status,
                DateTime? date,
                int pageNumber, 
                int pageSize
          
          );

       }
}
