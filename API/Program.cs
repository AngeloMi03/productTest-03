using Microsoft.AspNetCore.Mvc.Testing;
using Application;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;
using Persistence.IRepository;
using Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IProductRepository, ProductRepository>();  
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();  

builder.Services.AddDbContext<ProductDbContext>(opt =>
  {
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
 });


 builder.Services.AddMediatR(typeof(List));


WebApplication app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<ProductDbContext>();
    await context.Database.MigrateAsync();
    await DbInitializer.SeedData(context);
}
catch (Exception ex)
{

    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "an Error has occured");
}

app.Run();
