🧪 Lab 6: Updating and Deleting Records
📘 Scenario
The store needs the ability to update product prices and remove discontinued items from the database. This lab demonstrates how to use Entity Framework Core to update and delete records programmatically.

🎯 Objective
Use EF Core’s methods to:

✅ Update an existing product's price

🗑️ Delete a product by name

🧱 Prerequisites
AppDbContext properly configured

Database connection string set in appsettings.json

Initial seed data (e.g., "Laptop" and "Rice Bag") inserted from Lab 4 or Lab 5

🛠️ Steps
✅ Step 1: Update a Product
Update the price of the "Laptop" product from ₹75000 to ₹70000.

csharp
Copy
Edit
var product = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
if (product != null)
{
    product.Price = 70000;
    await context.SaveChangesAsync();
    Console.WriteLine($"\n✅ Updated '{product.Name}' price to ₹{product.Price}");
}
else
{
    Console.WriteLine("❌ 'Laptop' not found for update.");
}
🗑️ Step 2: Delete a Product
Delete the "Rice Bag" product from the database.

csharp
Copy
Edit
var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
if (toDelete != null)
{
    context.Products.Remove(toDelete);
    await context.SaveChangesAsync();
    Console.WriteLine($"\n🗑️ Deleted product: {toDelete.Name}");
}
else
{
    Console.WriteLine("❌ 'Rice Bag' not found for deletion.");
}
📦 Output Verification
Use the Swagger UI (https://localhost:7090/swagger) and confirm:

GET /Products no longer shows "Rice Bag"

"Laptop" now displays a price of ₹70000

✅ Success Criteria
Data is updated and deleted from the SQL Server database.

Changes are reflected in both console output and Swagger GET endpoints.