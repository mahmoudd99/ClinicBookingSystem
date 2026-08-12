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
        public async Task<List<Appointment>> GetDoctorAppointmentsAsync(int doctorId)
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Where(a => a.DoctorId == doctorId)
                .OrderBy(a => a.AppointmentDate)
                .ToListAsync();
        }
        public async Task<Appointment?> GetByIdAsync(int id)
        {
            return await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }
        //public async Task<List<Appointment>> SearchAsync(int? doctorId,string? patientName,AppointmentStatus? status,DateTime? date,int pageNumber,int pageSize)
        //{
        //    IQueryable<Appointment> query =
        //        _context.Appointments
        //        .Include(a => a.Patient);

        //    if (doctorId.HasValue)
        //        query = query.Where(a => a.DoctorId == doctorId);

        //    if (!string.IsNullOrWhiteSpace(patientName))
        //        query = query.Where(a =>
        //            a.Patient.FirstName.Contains(patientName)
        //            ||
        //            a.Patient.LastName.Contains(patientName));

        //    if (status.HasValue)
        //        query = query.Where(a => a.Status == status);

        //    if (date.HasValue)
        //        query = query.Where(a =>
        //            a.AppointmentDate.Date == date.Value.Date);

        //    query = query.OrderBy(a => a.AppointmentDate);

        //    query = query
        //        .Skip((pageNumber - 1) * pageSize)
        //        .Take(pageSize);

        //    return await query.ToListAsync();
        //}
        public async Task<(List<Appointment> Items, int TotalCount)> SearchAsync(
        int? doctorId,
        string? patientName,
        AppointmentStatus? status,
        DateTime? date,
        int pageNumber,
        int pageSize)
        {
            IQueryable<Appointment> query = _context.Appointments
                .Include(a => a.Patient);

            if (doctorId.HasValue)
                query = query.Where(a => a.DoctorId == doctorId);

            if (!string.IsNullOrWhiteSpace(patientName))
                query = query.Where(a =>
                    a.Patient.FirstName.Contains(patientName) ||
                    a.Patient.LastName.Contains(patientName));

            if (status.HasValue)
                query = query.Where(a => a.Status == status);

            if (date.HasValue)
                query = query.Where(a => a.AppointmentDate.Date == date.Value.Date);

            query = query.OrderBy(a => a.AppointmentDate);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

    }
}
