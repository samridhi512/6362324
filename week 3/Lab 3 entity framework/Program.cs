using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RetailInventory;
using RetailInventory.Models;

var builder = WebApplication.CreateBuilder(args);

// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Register DbContext
builder.Services.AddDbContext<RetailDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Database connection and optional seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        var dbContext = services.GetRequiredService<RetailDbContext>();

        if (dbContext.Database.CanConnect())
        {
            logger.LogInformation("✅ Connected to database successfully.");

            // Optional: Seed data
            SeedData(dbContext, logger);

            var products = dbContext.Products.Include(p => p.Category).ToList();
            logger.LogInformation("📦 Products in Inventory:");

            foreach (var product in products)
            {
                logger.LogInformation($"- {product.Name} ({product.Quantity} in stock) - Category: {product.Category?.Name}");
            }
        }
        else
        {
            logger.LogWarning("❌ Failed to connect to the database.");
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An unexpected error occurred during startup.");
    }
}

app.Run();

/// <summary>
/// Seeds initial data into the database if not already present.
/// </summary>
void SeedData(RetailDbContext context, ILogger logger)
{
    if (!context.Categories.Any())
    {
        logger.LogInformation("🌱 Seeding sample data...");

        var electronics = new Category { Name = "Electronics" };
        var groceries = new Category { Name = "Groceries" };

        context.Categories.AddRange(electronics, groceries);
        context.SaveChanges();

        var products = new List<Product>
        {
            new Product { Name = "Laptop", Quantity = 10, CategoryId = electronics.Id },
            new Product { Name = "Mobile Phone", Quantity = 25, CategoryId = electronics.Id },
            new Product { Name = "Rice", Quantity = 100, CategoryId = groceries.Id },
            new Product { Name = "Milk", Quantity = 50, CategoryId = groceries.Id }
        };

        context.Products.AddRange(products);
        context.SaveChanges();

        logger.LogInformation("✅ Sample data seeded successfully.");
    }
    else
    {
        logger.LogInformation("ℹ️ Sample data already exists. Skipping seeding.");
    }
}
