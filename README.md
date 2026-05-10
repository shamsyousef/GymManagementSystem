# 🏋️ Gym Management System

A modern and scalable Gym Management System built using .NET Web API following Onion Architecture principles.

The system manages gym operations such as members, trainers, sessions, bookings, and membership plans efficiently and securely.

---

# 🚀 Features (CRUD + Business Logic)

## 👤 Members
- Create / Update / Delete members
- Track membership start and end dates
- Membership status (Active / Expired)

## 🏋️ Trainers
- Manage trainers data
- Assign trainers to sessions
- Track availability

## 📅 Sessions
- Create sessions with capacity and schedule
- Assign trainers to sessions
- Prevent overbooking

## 📌 Bookings
- Members can book sessions
- Cancel bookings
- Validate capacity before booking

## 💳 Membership Plans
- Monthly / Yearly plans
- Pricing management
- Session limits per plan

---

# 🛠 Tech Stack

- Backend: .NET 10 / ASP.NET Core Web API
- Architecture: Onion Architecture
- Database: SQL Server
- ORM: Entity Framework Core (Code-First)
- Mapping: Dto,AutoMapper
- Authentication: JWT
- Documentation: Swagger / OpenAPI

---

# 🧱 Architecture

GymManagement/
├── Gym.Domain/          # Entities, Enums, Business Rules
├── Gym.Application/     # DTOs, Interfaces, Services
├── Gym.Infrastructure/  # DbContext, Repositories,unitofwork, EF Core
└── Gym.API/             # Controllers, Middleware, Program.cs

---

# 🔐 Authentication

- JWT Authentication
- Role-based Authorization:
  - Admin
  - Trainer
  - Member

---

# 📊 Business Rules

- Members cannot book full sessions
- Expired members cannot book sessions
- Each session has a capacity limit
- Trainers assigned only to valid sessions
- Membership plan controls access rules

---

# 📌 Future Improvements

- Payment integration
- Email notifications
- Refresh tokens
- Background jobs
- Docker support

---

# 🧠 Goal

This project demonstrates:
- Clean Architecture
- Real-world backend design
- Scalable Web API structure
- Separation of concerns
