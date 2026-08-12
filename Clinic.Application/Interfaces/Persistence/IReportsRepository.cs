using Clinic.Application.Features.Reports.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Interfaces.Persistence
{
    public interface IReportsRepository
    {
        Task<List<DoctorAppointmentReportDto>>
            GetDoctorAppointmentsReportAsync(int doctorId);

        Task<List<NewPatientReportDto>>
            GetNewPatientsReportAsync(int days);
        Task<List<TopDoctorReportDto>> GetTopDoctorsReportAsync();
    }
}
