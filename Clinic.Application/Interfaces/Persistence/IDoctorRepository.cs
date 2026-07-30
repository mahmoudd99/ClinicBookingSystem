using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Interfaces.Persistence
{
    public interface IDoctorRepository
    {
        Task AddAsync(Doctor doctor);

        Task<Doctor?> GetByIdAsync(int id);

        Task<List<Doctor>> GetAllAsync();

        Task UpdateAsync(Doctor doctor);

        Task DeleteAsync(Doctor doctor);
    }
}
