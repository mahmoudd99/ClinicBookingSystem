using Clinic.Application.Interfaces.Persistence;
using Clinic.Domain.Entities;
using Clinic.Domain.Enums.AppointmentStatus;
using Clinic.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Persistence.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ClinicDbContext _context;

        public AppointmentRepository(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsDoctorAvailableAsync(
            int doctorId,
            DateTime appointmentDate)
        {
            return !await _context.Appointments.AnyAsync(x =>
                x.DoctorId == doctorId &&
                x.AppointmentDate == appointmentDate &&
                x.Status != AppointmentStatus.Cancelled);
        }
    }
}
