# 🧪 Lab 5: Retrieving Data from the Database

## 📌 Scenario
The retail store wants to **display product details on the dashboard**. This lab focuses on retrieving data using **Entity Framework Core**.

---

## 🎯 Objective
Use the following EF Core methods to retrieve data from the database:
- `ToListAsync()` – To get all products.
- `FindAsync(id)` – To find a product by its primary key.
- `FirstOrDefaultAsync(predicate)` – To find the first product that matches a condition.

---

## 🛠️ Technologies Used
- ASP.NET Core 7 / 8 Web API
- Entity Framework Core
- SQL Server (LocalDB or external)
- Swagger UI for testing endpoints

---

## 🚀 Setup Instructions

1. Ensure your connection string in `appsettings.json` is valid under `"DefaultConnection"`.

2. In `Program.cs`, data seeding and query logic is performed inside:
   ```csharp
   using (var scope = app.Services.CreateScope())
   {
       var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
       context.Database.EnsureCreated();
       
       // Seed if empty
       if (!context.Categories.Any())
       {
           var electronics = new Category { Name = "Electronics" };
           var groceries = new Category { Name = "Groceries" };

           await context.Categories.AddRangeAsync(electronics, groceries);

           var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
           var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

           await context.Products.AddRangeAsync(product1, product2);
           await context.SaveChangesAsync();
       }

       // Retrieve All Products
       var products = await context.Products.ToListAsync();
       foreach (var p in products)
           Console.WriteLine($"{p.Name} - ₹{p.Price}");

       // Find Product by ID
       var productById = await context.Products.FindAsync(1);
       Console.WriteLine($"\nFound: {productById?.Name}");

       // Get First Expensive Product
       var expensiveProduct = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
       Console.WriteLine($"\nExpensive: {expensiveProduct?.Name}");
   }
