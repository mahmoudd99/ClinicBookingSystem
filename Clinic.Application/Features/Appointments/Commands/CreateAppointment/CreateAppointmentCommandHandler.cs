using AutoMapper;
using Clinic.Domain.Exceptions;
using Clinic.Application.Exceptions; 
using Clinic.Application.Interfaces.Persistence;
using Clinic.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandHandler
    : IRequestHandler<CreateAppointmentCommand, int>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;

        public CreateAppointmentCommandHandler(
            IAppointmentRepository appointmentRepository,
            IDoctorRepository doctorRepository,
            IPatientRepository patientRepository,
            IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(
            CreateAppointmentCommand request,
            CancellationToken cancellationToken)
        {

            var doctor = await _doctorRepository.GetByIdAsync(request.DoctorId);

            if (doctor is null)
            {
                throw new NotFoundException(nameof(Doctor), request.DoctorId);
            }

            var patient = await _patientRepository.GetByIdAsync(request.PatientId);

            if (patient is null)
            {
                throw new NotFoundException(nameof(Patient), request.PatientId);
            }
            if (!await _appointmentRepository.IsDoctorAvailableAsync(
                request.DoctorId,
                request.AppointmentDate))
            {
                throw new Domain.Exceptions.BusinessException("Doctor already has an appointment at this time.");
            }
            var appointment = new Appointment(
                            request.DoctorId,
                            request.PatientId,
                            request.AppointmentDate,
                            request.Notes);

            await _appointmentRepository.AddAsync(appointment);

            return appointment.Id;

            
        }
    }
}
