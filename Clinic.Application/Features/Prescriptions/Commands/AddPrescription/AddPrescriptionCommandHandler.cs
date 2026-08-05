using Clinic.Application.Features.Prescriptions.Commands.AddPrescription;
using Clinic.Application.Interfaces.Persistence;
using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Prescriptions.Commands.AddPrescription
{
    public class AddPrescriptionCommandHandler
    : IRequestHandler<AddPrescriptionCommand, int>
    {
        private readonly IPrescriptionRepository _prescriptionRepository;

        public AddPrescriptionCommandHandler(
            IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        public async Task<int> Handle(
            AddPrescriptionCommand request,
            CancellationToken cancellationToken)
        {
            var prescription = new Prescription(
                request.MedicalRecordId,
                request.MedicationName,
                request.Dosage,
                request.Instructions);

            await _prescriptionRepository.AddAsync(prescription);

            return prescription.Id;
        }
    }
}
