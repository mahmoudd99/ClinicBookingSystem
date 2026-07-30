using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class Doctor
    {
        private Doctor()
        {
        }

        public Doctor(string firstName,string lastName,string email,string phoneNumber,int specializationId)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name is required.");

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            SpecializationId = specializationId;
        }
        public void Update(string firstName,string lastName,string email,string phoneNumber,int specializationId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            SpecializationId = specializationId;
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; } = string.Empty;

        public string LastName { get; private set; } = string.Empty;

        public string Email { get; private set; } = string.Empty;

        public string PhoneNumber { get; private set; } = string.Empty;

        public int SpecializationId { get; private set; }

        public Specialization Specialization { get; private set; } = null!;


        public void ChangePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number is required.");

            if (phoneNumber.Length != 11)
                throw new ArgumentException("Phone number must be 11 digits.");

            if (!phoneNumber.StartsWith("010") &&
                !phoneNumber.StartsWith("011") &&
                !phoneNumber.StartsWith("012") &&
                !phoneNumber.StartsWith("015"))
            {
                throw new ArgumentException("Invalid Egyptian phone number.");
            }

            PhoneNumber = phoneNumber;
        }
    }

}