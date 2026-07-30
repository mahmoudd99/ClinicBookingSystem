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
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(d => d.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(d => d.Email)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(d => d.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(11);
        }





    }
}
