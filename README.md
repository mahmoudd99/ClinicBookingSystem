# 🏥 Clinic Management System - Frontend

A modern Angular frontend for a Clinic Management System designed to manage doctors, patients, appointments, and authentication workflows.

The application provides a clean dashboard interface with protected routes, reusable layout components, and REST API integration with an ASP.NET Core backend.

---

## 🚀 Features

### 🔐 Authentication

- User Login
- User Registration
- Logout
- JWT Authentication
- Access Token Management
- Refresh Token Support
- Authentication Guard
- Protected Routes

### 🧭 Clinic Dashboard

- Modern Dashboard
- Reusable Sidebar Layout
- User Information
- Navigation Between Clinic Features
- Responsive Interface

### 👨‍⚕️ Doctors Management

- View Doctors
- Add Doctor
- Edit Doctor
- Delete Doctor
- Doctor Specialization
- Doctor Information Management

### 🧑‍🤝‍🧑 Patients Management

- View Patients
- Patient Information
- Patient Management
- Loading and Error Handling

### 📅 Appointments Management

- View Appointments
- Add Appointment
- Confirm Appointment
- Cancel Appointment
- Search Appointments
- Filter Appointments
- Filter by Doctor
- Filter by Patient
- Filter by Status
- Filter by Date
- Pagination

---

## 🖥️ Application Structure

```text
src/app
│
├── core
│   ├── guards
│   │   ├── auth-guard
│   │   └── role-guard
│   │
│   ├── models
│   │
│   └── services
│       ├── auth
│       ├── doctor
│       ├── patient
│       └── appointment
│
├── features
│   │
│   ├── auth
│   │   ├── login
│   │   └── register
│   │
│   ├── dashboard
│   │   └── dashboard
│   │
│   ├── doctors
│   │   ├── list
│   │   ├── add
│   │   └── edit
│   │
│   ├── patients
│   │   └── list
│   │
│   └── appointments
│       ├── list
│       └── add
│
└── shared
    └── layout
        ├── layout.ts
        ├── layout.html
        └── layout.css
