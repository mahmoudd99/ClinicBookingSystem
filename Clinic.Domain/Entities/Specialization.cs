using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class Specialization
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
