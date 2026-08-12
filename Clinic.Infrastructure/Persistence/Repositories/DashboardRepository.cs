using Clinic.Application.Features.Dashboard.DTOs;
using Clinic.Application.Interfaces.Persistence;
using Clinic.Domain.Enums.AppointmentStatus;
using Clinic.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Persistence.Repositories;

public class DashboardRepository : IDashboardRepository
{
    private readonly ClinicDbContext _context;

    public DashboardRepository(ClinicDbContext context)
    {
        _context = context;
    }

    public async Task<DashboardStatisticsDto> GetStatisticsAsync()
    {
        return new DashboardStatisticsDto
        {
            TotalDoctors = await _context.Doctors.CountAsync(),

            TotalPatients = await _context.Patients.CountAsync(),

            TotalAppointments = await _context.Appointments.CountAsync(),

            PendingAppointments = await _context.Appointments
                .CountAsync(x => x.Status == AppointmentStatus.Pending),

            ConfirmedAppointments = await _context.Appointments
                .CountAsync(x => x.Status == AppointmentStatus.Confirmed),

            CancelledAppointments = await _context.Appointments
                .CountAsync(x => x.Status == AppointmentStatus.Cancelled),

            TodayAppointments = await _context.Appointments
                .CountAsync(x => x.AppointmentDate.Date == DateTime.Today)
        };
    }
}
