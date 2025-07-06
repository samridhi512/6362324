# 🛒 RetailStoreApp

**RetailStoreApp** is an ASP.NET Core Web API project built for managing product categories and products in a retail store using Entity Framework Core and SQL Server. This project was created as part of Lab 4 to demonstrate database setup, migrations, and initial data seeding using EF Core.

---

## 📌 Features

- ASP.NET Core 8.0 Web API
- Entity Framework Core (EF Core)
- SQL Server Integration
- Code-First Migrations
- Initial data seeding
- Swagger UI for API testing

---

## ⚙️ Technologies Used

- ASP.NET Core
- C#
- Entity Framework Core
- SQL Server / LocalDB
- Visual Studio
- Swagger (Swashbuckle)

---

## 🗂️ Project Structure

RetailStoreApp/
├── Controllers/ # API Controllers (optional for extensions)
├── Data/
│ ├── AppDbContext.cs # EF Core database context
│ └── AppDbContextFactory.cs# Factory class for migrations
├── Models/
│ ├── Category.cs # Category model
│ └── Product.cs # Product model
├── Migrations/ # EF Core migrations
├── Program.cs # Main application logic and seeding
├── appsettings.json # Database configuration
└── README.md # Project documentation


---

## 🔧 Getting Started

### 🖥️ Prerequisites

- Visual Studio 2022 or later
- .NET 8 SDK
- SQL Server or LocalDB

---

### 🚀 Running the App

1. Clone or download the project.
2. Open it in **Visual Studio**.
3. Open `appsettings.json` and ensure the connection string is valid:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=RetailStoreDb;Trusted_Connection=True;"
     }
   }


