using Clinic.Application.Interfaces.Persistence;
using Clinic.Domain.Entities;
using Clinic.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Persistence.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly ClinicDbContext _context;

        public PrescriptionRepository(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Prescription prescription)
        {
            await _context.Prescriptions.AddAsync(prescription);
            await _context.SaveChangesAsync();
        } }
    }
