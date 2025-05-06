using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SQR.Backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ProductionContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Add Swagger services
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(c => { 
    c.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "SQR Production API", 
        Version = "v1",
        Description = "API for managing production orders and records" 
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
 if (app.Environment.IsDevelopment()) { 
    app.UseSwagger(); 
    app.UseSwaggerUI(c => { 
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SQR Production API v1");
    c.RoutePrefix = string.Empty; // Makes Swagger UI available at the root URL
    });
 }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
