using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Persistence.Configurations
{
    public class AppointmentConfiguration
    : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Notes)
                   .HasMaxLength(500);

            builder.HasOne(x => x.Doctor)
                   .WithMany(x => x.Appointments)
                   .HasForeignKey(x => x.DoctorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Patient)
                   .WithMany(x => x.Appointments)
                   .HasForeignKey(x => x.PatientId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }




}
