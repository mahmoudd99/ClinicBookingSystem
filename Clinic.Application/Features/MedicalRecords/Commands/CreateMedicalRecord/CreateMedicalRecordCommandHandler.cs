using Clinic.Application.Interfaces.Persistence;
using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.MedicalRecords.Commands.CreateMedicalRecord
{
    public class CreateMedicalRecordCommandHandler
         : IRequestHandler<CreateMedicalRecordCommand, int>
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public CreateMedicalRecordCommandHandler(
            IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public async Task<int> Handle(
            CreateMedicalRecordCommand request,
            CancellationToken cancellationToken)
        {
            var medicalRecord = new MedicalRecord(
                request.PatientId,
                request.DoctorId,
                request.VisitDate,
                request.Diagnosis,
                request.Notes);

            await _medicalRecordRepository.AddAsync(medicalRecord);

            return medicalRecord.Id;
        }
    }
}
