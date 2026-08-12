using Clinic.Application.Features.Reports.DTOs;
using Clinic.Application.Interfaces.Persistence;
using Clinic.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure.Persistence.Repositories
{
    public class ReportsRepository : IReportsRepository
    {
        private readonly ClinicDbContext _context;

        public ReportsRepository(ClinicDbContext context)
        {
            _context = context;
        }

        // 1. Doctor Appointments Report
        public async Task<List<DoctorAppointmentReportDto>>GetDoctorAppointmentsReportAsync(int doctorId)
        {
            return await _context.Appointments
                .Where(a => a.DoctorId == doctorId)
                .Include(a => a.Patient)
                .OrderBy(a => a.AppointmentDate)
                .Select(a => new DoctorAppointmentReportDto
                {
                    PatientName =
                        $"{a.Patient.FirstName} {a.Patient.LastName}",

                    AppointmentDate = a.AppointmentDate,

                    Status = a.Status.ToString()
                })
                .ToListAsync();
        }

        // 2. New Patients Report
        public async Task<List<NewPatientReportDto>>GetNewPatientsReportAsync(int days)
        {
            var fromDate = DateTime.UtcNow.AddDays(-days);

            return await _context.Patients
                .Where(p => p.CreatedAt >= fromDate)
                .OrderByDescending(p => p.CreatedAt)
                .Select(p => new NewPatientReportDto
                {
                    PatientId = p.Id,

                    PatientName =
                        $"{p.FirstName} {p.LastName}",

                    PhoneNumber = p.PhoneNumber,

                    CreatedAt = p.CreatedAt
                })
                .ToListAsync();
        }

        // 3. Top Doctors Report
        public async Task<List<TopDoctorReportDto>> GetTopDoctorsReportAsync()
        {
            return await _context.Appointments
                .GroupBy(a => a.DoctorId)
                .Select(g => new TopDoctorReportDto
                {
                    DoctorId = g.Key,

                    DoctorName = "Doctor " + g.Key,

                    AppointmentCount = g.Count()
                })
                .OrderByDescending(x => x.AppointmentCount)
                .ToListAsync();
        }
    }
}