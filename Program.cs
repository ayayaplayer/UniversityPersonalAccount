using Microsoft.EntityFrameworkCore;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Mappings;
using UniversityPersonalAccount.Services.Interfaces;
using UniversityPersonalAccount.Services.CourseService;
using UniversityPersonalAccount.Services.FacultyService;
using UniversityPersonalAccount.Services.GroupService;
using UniversityPersonalAccount.Services.HalfYearService;
using UniversityPersonalAccount.Services.SchdeuleService;
using UniversityPersonalAccount.Services.SessionService;
using UniversityPersonalAccount.Services.StudentService;





var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseWithGroupService, CourseWithGroupService>();
builder.Services.AddScoped<IFacultyService, FacultyService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IHalfYearService, HalfYearService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
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
app.MapControllers();
app.Run();