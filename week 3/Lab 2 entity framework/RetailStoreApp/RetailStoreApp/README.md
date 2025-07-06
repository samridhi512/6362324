# 🛒 RetailStoreApp

This project is a basic ASP.NET Core Web API for a retail store. It allows management of product categories and product listings using Entity Framework Core and SQL Server.

---

## 🚀 Features

- ASP.NET Core Web API
- Entity Framework Core with Code-First
- SQL Server Database Integration
- Swagger for testing APIs
- Initial data seeding (Categories and Products)

---

## 📂 Project Structure

RetailStoreApp/
├── Controllers/
├── Data/
│ ├── AppDbContext.cs
│ └── AppDbContextFactory.cs
├── Models/
│ ├── Category.cs
│ └── Product.cs
├── Migrations/
├── Program.cs
├── appsettings.json
└── README.md

yaml
Copy
Edit


---

## ⚙️ How to Run

1. **Restore dependencies** (if not already):
   - Visual Studio does this automatically.
2. **Update the database:**
   - Open **Package Manager Console** and run:
     ```powershell
     Update-Database
     ```
3. **Run the app** using `F5` or the **Start** button.
4. **Test the APIs** on `https://localhost:<port>/swagger`

---

## 🧪 Seeded Data

### 📁 Categories:
- Electronics
- Groceries

### 📦 Products:
- Laptop (₹75,000) – Electronics
- Rice Bag (₹1,200) – Groceries

---

## 📌 Technologies Used

- ASP.NET Core 8.0
- C#
- Entity Framework Core
- SQL Server LocalDB
- Swagger / OpenAPI

---

## 👨‍💻 Author

**Samridhi Shree**  
📍 Patna, Bihar  
🎓 KIIT University  
💼 Passionate about Building Real World projects and Exploring Open Source.