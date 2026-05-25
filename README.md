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

<img width="1671" height="1331" alt="Car Rental drawio" src="https://github.com/user-attachments/assets/e47ba741-074a-4e5a-a626-1b2f0eb6de9a" />

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

# 📸 Screenshots
<img width="800" height="518" alt="image" src="https://github.com/user-attachments/assets/bc95ffbd-b514-4dae-969e-fddc68a6c467" />
<img width="1384" height="846" alt="image" src="https://github.com/user-attachments/assets/804dbb93-7d5d-4775-af5e-24052c958700" />
<img width="1379" height="850" alt="image" src="https://github.com/user-attachments/assets/0c613e42-facf-4153-87e9-1afe8acbda5d" />
<img width="1380" height="850" alt="image" src="https://github.com/user-attachments/assets/eafafdf1-9b0f-4605-9648-c41efc247fe2" />
<img width="1375" height="844" alt="image" src="https://github.com/user-attachments/assets/f4b220e0-8585-4895-8b14-81d3ff9cb72b" />
<img width="1371" height="846" alt="image" src="https://github.com/user-attachments/assets/0c06d697-cfcb-4990-a9cf-1dd28f7b3fd8" />
<img width="1377" height="849" alt="image" src="https://github.com/user-attachments/assets/6380206d-865f-40e5-ae02-979745f71334" />
<img width="1083" height="922" alt="image" src="https://github.com/user-attachments/assets/d101c560-5495-4c1e-8ccb-7d7b48a8830f" />
<img width="1105" height="766" alt="image" src="https://github.com/user-attachments/assets/5bb92ada-dfd2-4918-9b8c-c4a245fe7c41" />
<img width="1343" height="654" alt="image" src="https://github.com/user-attachments/assets/05518a87-25e8-4fc3-b71c-916f37759001" />
<img width="1079" height="632" alt="image" src="https://github.com/user-attachments/assets/4c441fbc-d89f-4c2a-a0ea-fd927c780598" />
<img width="1079" height="774" alt="image" src="https://github.com/user-attachments/assets/8d9d89e8-efdd-4910-8f78-424595c2ab5a" />



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
