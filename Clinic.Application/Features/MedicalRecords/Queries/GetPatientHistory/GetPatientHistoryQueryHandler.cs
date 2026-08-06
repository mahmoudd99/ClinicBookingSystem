using Clinic.Application.Features.MedicalRecords.DTOS;
using Clinic.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.MedicalRecords.Queries.GetPatientHistory
{
    public class GetPatientHistoryQueryHandler
        : IRequestHandler<GetPatientHistoryQuery, List<MedicalRecordDto>>
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public GetPatientHistoryQueryHandler(
            IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public async Task<List<MedicalRecordDto>> Handle(
            GetPatientHistoryQuery request,
            CancellationToken cancellationToken)
        {
            var history = await _medicalRecordRepository
                .GetPatientHistoryAsync(request.PatientId);

            return history.Select(record => new MedicalRecordDto
            {
                VisitDate = record.VisitDate,

                DoctorName =
                    $"{record.Doctor.FirstName} {record.Doctor.LastName}",

                Diagnosis = record.Diagnosis,

                Notes = record.Notes,

                Prescriptions = record.Prescriptions
                    .Select(p => new PrescriptionDto
                    {
                        MedicationName = p.MedicationName,
                        Dosage = p.Dosage,
                        Instructions = p.Instructions
                    }).ToList()

            }).ToList();
        }
    }
}
