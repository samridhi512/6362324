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


    var filtered = await context.Products
        .Where(p => p.Price > 1000)
        .OrderByDescending(p => p.Price)
        .ToListAsync();

    Console.WriteLine("\n🔽 Filtered & Sorted Products (Price > 1000):");
    foreach (var p in filtered)
        Console.WriteLine($"{p.Name} - ₹{p.Price}");

    var productDTOs = await context.Products
        .Select(p => new { p.Name, p.Price })
        .ToListAsync();

    Console.WriteLine("\n📋 Product DTOs (Name & Price):");
    foreach (var dto in productDTOs)
        Console.WriteLine($"Name: {dto.Name}, Price: ₹{dto.Price}");
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
