using Microsoft.EntityFrameworkCore;
using UniversityPersonalAccount.Data;
using AutoMapper;
using UniversityPersonalAccount.Models.DTOs;
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<PersonalAccountDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PersonalAccountDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.UseHttpsRedirection();
app.MapControllers();
app.Run();