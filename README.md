# 🚗 Car Rental Management System

A desktop-based Car Rental Management System built using **C# .NET Framework (WinForms)** and **SQL Server**.

The project was designed to simulate a real-world rental management workflow with a clean UI, structured architecture, and practical business logic.

---

# ✨ Features

## 🚘 Vehicle Management
- Add / Update vehicles
- Vehicle availability tracking
- Vehicle status management
- Vehicle image support
- Manage:
  - Makes
  - Models
  - Years
  - Fuel Types
  - Transmissions

---

## 👥 Customer Management
- Add and manage customers
- National number validation
- License number support
- Customer rental history integration

---

## 📄 Rental Management
- Create rental records
- Calculate rental duration and total price
- Deposit handling
- Initial payments
- Rental extensions
- Vehicle return workflow
- Automatic availability updates

---

## 💳 Payment System
- Payment history tracking
- Initial / Return / Extension payments
- Refund support
- Financial overview dashboard
- Net revenue calculations

---

## 👨‍💼 User & Role Management
- User authentication
- Role management
- User activation/deactivation
- Role assignment system

---

## 📊 Dashboard
- Total vehicles
- Available vehicles
- Rented vehicles
- Total customers
- Financial overview cards
- Quick actions section

---

# 🛠️ Technologies Used

- C#
- .NET Framework
- WinForms
- SQL Server
- ADO.NET
- Guna UI2
- FontAwesome.Sharp

---

# 🧱 Project Architecture

The project follows a simple **3-Layer Architecture**:

```text
Presentation Layer (WinForms UI)
Business Layer
Data Access Layer
```

---

# 🗄️ Database

The project includes:
- Tables
- Foreign Keys
- Constraints
- Views
- Stored Procedures

Database script:

```text
CarsRentalSystem.sql
```

---

# ▶️ How To Run

## 1. Clone the repository

```bash
git clone <repository-url>
```

---

## 2. Restore the database

Open SQL Server Management Studio and execute:

```text
CarsRentalSystem.sql
```

---

## 3. Update the connection string

Modify the SQL Server connection string inside:

```text
DataAccessSettings.cs
```

---

## 4. Open the solution

Open:

```text
Cars Rental.sln
```

using Visual Studio.

---

## 5. Run the project

Build and run the application.

---

# 📚 What I Learned

Through this project, I gained practical experience with:
- Desktop application development
- Database design
- Business workflow implementation
- UI organization and consistency
- SQL Server & Stored Procedures
- Layered architecture
- Reusable UI components

---

# 📌 Notes

This project represents the first complete version of the system and was built mainly for learning and practical experience.
