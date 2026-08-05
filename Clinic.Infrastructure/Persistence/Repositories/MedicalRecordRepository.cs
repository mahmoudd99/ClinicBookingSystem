using Clinic.Application.Interfaces.Persistence;
using Clinic.Domain.Entities;
using Clinic.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Persistence.Repositories
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly ClinicDbContext _context;

        public MedicalRecordRepository(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MedicalRecord medicalRecord)
        {
            await _context.MedicalRecords.AddAsync(medicalRecord);
            await _context.SaveChangesAsync();
        }

        public async Task<MedicalRecord?> GetByIdAsync(int id)
        {
            return await _context.MedicalRecords
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .Include(x => x.Prescriptions)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<MedicalRecord>> GetPatientHistoryAsync(int patientId)
        {
            return await _context.MedicalRecords
                .Include(x => x.Doctor)
                .Include(x => x.Prescriptions)
                .Where(x => x.PatientId == patientId)
                .OrderByDescending(x => x.VisitDate)
                .ToListAsync();
        }
    }
}
        
