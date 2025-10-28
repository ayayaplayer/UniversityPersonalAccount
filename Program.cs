using Microsoft.EntityFrameworkCore;
using UniversityPersonalAccount.Data;
using UniversityPersonalAccount.Mappings;
using UniversityPersonalAccount.Services;
using UniversityPersonalAccount.Services.Interfaces;





var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IFacultyService, FacultyService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IHalfYearService, HalfYearService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<PersonalAccountDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddControllers();
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
app.MapControllers();
try
{
    var serviceProvider = app.Services;
    
    // Попробуйте получить CourseService
    var courseService = serviceProvider.GetRequiredService<ICourseService>();
    Console.WriteLine("✅ CourseService успешно разрешён");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Ошибка: {ex.Message}");
    if (ex.InnerException != null)
    {
        Console.WriteLine($"InnerException: {ex.InnerException.Message}");
    }
}

app.Run();