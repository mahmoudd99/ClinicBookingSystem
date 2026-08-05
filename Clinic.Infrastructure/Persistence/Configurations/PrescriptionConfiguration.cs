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
    public class PrescriptionConfiguration
        : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.MedicationName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Dosage)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Instructions)
                .HasMaxLength(500);

            builder.HasOne(x => x.MedicalRecord)
                .WithMany(x => x.Prescriptions)
                .HasForeignKey(x => x.MedicalRecordId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
