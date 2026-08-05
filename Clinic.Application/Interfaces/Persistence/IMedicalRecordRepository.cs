using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Interfaces.Persistence
{
    public interface IMedicalRecordRepository
    {
        Task AddAsync(MedicalRecord medicalRecord);

        Task<MedicalRecord?> GetByIdAsync(int id);

        Task<List<MedicalRecord>> GetPatientHistoryAsync(int patientId);
    }
}
