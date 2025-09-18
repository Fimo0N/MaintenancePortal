using MaintenancePortal.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configure DbContext with SQL Server
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// ******************************************************
// ***** 1. ADD CORS SERVICES (START) *****
// ******************************************************
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // This is our Angular app's address
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
// ******************************************************
// ***** 1. ADD CORS SERVICES (END) *****
// ******************************************************


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ******************************************************
// ***** 2. USE THE CORS POLICY (START) *****
// ******************************************************
app.UseCors("AllowSpecificOrigin");
// ******************************************************
// ***** 2. USE THE CORS POLICY (END) *****
// ******************************************************


app.UseAuthorization();

app.MapControllers();

app.Run();

// This line is added to help with EF Core design-time tools.
public partial class Program { }

