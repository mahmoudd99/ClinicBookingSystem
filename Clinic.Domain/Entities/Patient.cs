using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class Patient
    {
        public int Id { get; private set; }

        public string FirstName { get; private set; } = string.Empty;

        public string LastName { get; private set; } = string.Empty;

        public string NationalId { get; private set; } = string.Empty;

        public string PhoneNumber { get; private set; } = string.Empty;

        public DateTime DateOfBirth { get; private set; }

        public string Gender { get; private set; } = string.Empty;

        public string Address { get; private set; } = string.Empty;

        public ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();
        public ICollection<MedicalRecord> MedicalRecords { get; private set; }= new List<MedicalRecord>();
        private Patient()
        {

        }

        public Patient(
            string firstName,
            string lastName,
            string nationalId,
            string phoneNumber,
            DateTime dateOfBirth,
            string gender,
            string address)
        {
            FirstName = firstName;
            LastName = lastName;
            NationalId = nationalId;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
        }

        public void Update(
            string firstName,
            string lastName,
            string nationalId,
            string phoneNumber,
            DateTime dateOfBirth,
            string gender,
            string address)
        {
            FirstName = firstName;
            LastName = lastName;
            NationalId = nationalId;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
        }
    }
}
