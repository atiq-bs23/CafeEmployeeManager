using CafeEmployeeManager.Application.DTOs;
using CafeEmployeeManager.Application.Mappings;
using CafeEmployeeManager.Application.Services;
using CafeEmployeeManager.Application.Services.Interfaces;
using CafeEmployeeManager.Application.Validators;
using CafeEmployeeManager.Data.Context;
using CafeEmployeeManager.Data.Repositories;
using CafeEmployeeManager.Data.Repositories.Base;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IValidator<EmployeeDto>, EmployeeDtoValidator>();
builder.Services.AddScoped<IValidator<CafeDto>, CafeDtoValidator>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddDbContext<CafeEmployeeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICafeRepository, CafeRepository>();
builder.Services.AddScoped<IEmployeeCafeAssignmentRepository, EmployeeCafeAssignmentRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ICafeService, CafeService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
