using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Dashboard.DTOs;

public class DashboardStatisticsDto
{
    public int TotalDoctors { get; set; }

    public int TotalPatients { get; set; }

    public int TotalAppointments { get; set; }

    public int PendingAppointments { get; set; }

    public int ConfirmedAppointments { get; set; }

    public int CancelledAppointments { get; set; }

    public int TodayAppointments { get; set; }
}
