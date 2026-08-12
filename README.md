# 🏥 Clinic Management System - Backend

A scalable RESTful API for managing clinic operations, built with ASP.NET Core and following Clean Architecture principles.

The system provides APIs for managing doctors, patients, appointments, authentication, and clinic workflows.

---

## 🚀 Features

### 🔐 Authentication & Authorization
- User Registration
- User Login
- JWT Authentication
- Refresh Tokens
- Role-Based Authorization
- Secure Password Management

### 👨‍⚕️ Doctors
- Create Doctor
- Update Doctor
- Delete Doctor
- Get Doctors
- Doctor Specialization Management

### 🧑‍🤝‍🧑 Patients
- Create Patient
- Update Patient
- Delete Patient
- Get Patients

### 📅 Appointments
- Create Appointment
- Confirm Appointment
- Cancel Appointment
- Search Appointments
- Filter by Doctor
- Filter by Patient
- Filter by Status
- Filter by Date
- Pagination

---

## 🏗️ Architecture

The project follows **Clean Architecture** to maintain separation of concerns and make the application scalable and maintainable.

```text
Clinic
│
├── Clinic.API
│
├── Clinic.Application
│   ├── Features
│   ├── DTOs
│   ├── Interfaces
│   ├── Commands
│   └── Queries
│
├── Clinic.Domain
│   ├── Entities
│   ├── Enums
│   ├── Exceptions
│   └── Identity
│
└── Clinic.Infrastructure
    ├── Persistence
    ├── Repositories
    ├── Authentication
    └── Services
