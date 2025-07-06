🧪 Lab 7: Writing Queries with LINQ
✅ Scenario:
The store wants to filter and sort products for reporting purposes.

🎯 Objective:
Use LINQ queries (Where, Select, OrderBy) in Entity Framework Core to:

Filter products

Sort products by price

Project product data into DTOs (Data Transfer Objects)

🛠️ Setup & Prerequisites:
Ensure the following are done before running this lab:

The project is set up using ASP.NET Core Web API with Entity Framework Core.

AppDbContext, Product, and Category models exist and are properly configured.

Database is seeded with sample data (like "Laptop", "Rice Bag").

🧾 LINQ Operations Implemented
Filter and Sort Products
Retrieve all products with price > 1000 and sort them in descending order:

csharp
Copy
Edit
var filtered = await context.Products
    .Where(p => p.Price > 1000)
    .OrderByDescending(p => p.Price)
    .ToListAsync();
Project Products into DTOs
Select only Name and Price fields:

csharp
Copy
Edit
var productDTOs = await context.Products
    .Select(p => new { p.Name, p.Price })
    .ToListAsync();
🖥️ Console Output Example:
yaml
Copy
Edit
🔽 Filtered & Sorted Products (Price > 1000):
Laptop - ₹75000

📋 Product DTOs (Name & Price):
Name: Laptop, Price: ₹75000
Note: If "Rice Bag" was deleted in Lab 6, only "Laptop" will show.

🚀 How to Run:
Open the project in Visual Studio.

Ensure the correct startup project is selected.

Click on the green ▶️ Start button or use:

bash
Copy
Edit
dotnet run --project ./RetailStoreApp/RetailStoreApp.csproj
View the output in the Console window.