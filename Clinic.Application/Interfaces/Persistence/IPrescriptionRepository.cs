using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Interfaces.Persistence
{
    public interface IPrescriptionRepository
    {
        Task AddAsync(Prescription prescription);
    }
}
