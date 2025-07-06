using Microsoft.EntityFrameworkCore;
using RetailStoreApp.Data;
using RetailStoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();

    if (!context.Categories.Any())
    {
        var electronics = new Category { Name = "Electronics" };
        var groceries = new Category { Name = "Groceries" };

        await context.Categories.AddRangeAsync(electronics, groceries);

        var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
        var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

        await context.Products.AddRangeAsync(product1, product2);
        await context.SaveChangesAsync();

        Console.WriteLine("✅ Initial data inserted successfully.");
    }

    var products = await context.Products.ToListAsync();
    Console.WriteLine("\n📦 All Products:");
    foreach (var p in products)
        Console.WriteLine($"{p.Name} - ₹{p.Price}");

    var productById = await context.Products.FindAsync(1);
    Console.WriteLine($"\n🔍 Product with ID 1: {productById?.Name}");

    var expensiveProduct = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
    Console.WriteLine($"\n💰 Expensive Product (Price > 50000): {expensiveProduct?.Name}");

    var productToUpdate = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
    if (productToUpdate != null)
    {
        productToUpdate.Price = 70000;
        await context.SaveChangesAsync();
        Console.WriteLine($"\n✅ Updated '{productToUpdate.Name}' price to ₹{productToUpdate.Price}");
    }
    else
    {
        Console.WriteLine("❌ 'Laptop' not found for update.");
    }
    var productToDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
    if (productToDelete != null)
    {
        context.Products.Remove(productToDelete);
        await context.SaveChangesAsync();
        Console.WriteLine($"\n🗑️ Deleted product: {productToDelete.Name}");
    }
    else
    {
        Console.WriteLine("❌ 'Rice Bag' not found for deletion.");
    }

}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
