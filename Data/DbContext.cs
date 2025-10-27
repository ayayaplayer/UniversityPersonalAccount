using Microsoft.EntityFrameworkCore;
using UniversityPersonalAccount.Models.Entities;

namespace UniversityPersonalAccount.Data;

public class PersonalAccountDbContext : DbContext
{
    public PersonalAccountDbContext(DbContextOptions<PersonalAccountDbContext> options)
        : base(options)
    {
        
    }
        
   
    public DbSet<Student> Students { get; set; }
    public DbSet<Faculty> Faculties { get; set; }

    public DbSet<Course> Courses { get; set; }

    public DbSet<Session> Sessions { get; set; }
    public DbSet<HalfYear> HalfYears { get; set; }
    public DbSet<Group> Groups { get; set; }

    public DbSet<Schedule> Schedules { get; set; }
    public string? DbPath { get; }

    
    public PersonalAccountDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "PersonalAccount.db");
    }


    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Session>()
            .ToTable(t => t.HasCheckConstraint("CKClassNumber", " \"ClassNumber\" > 0 AND \"ClassNumber\" < 8"));
        modelBuilder.Entity<Session>()
           .ToTable(t => t.HasCheckConstraint("CKValidateSessionTime", " \"EndTime\" >  \"StartTime\" "));
        modelBuilder.Entity<HalfYear>()
            .ToTable(t => t.HasCheckConstraint("CKValidateDate", " \"DateEnd\" >  \"DateStart\" < "));
        modelBuilder.Entity<Student>()
            .ToTable(t => t.HasCheckConstraint("CKValidateEmail", " \"Email\" ~ ^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$' "));
        modelBuilder.Entity<Course>()
    .ToTable(t => t.HasCheckConstraint("CKDegreeCourseValid", @"
        (""DegreeLevel"" = 1 AND ""CourseName"" > 0 AND ""CourseName"" < 5)
        OR
        (""DegreeLevel"" = 2 AND ""CourseName"" > 0 AND ""CourseName"" < 3)
        OR
        (""DegreeLevel"" = 3 AND ""CourseName"" > 0 AND ""CourseName"" < 4)
    "));
    }
    

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql("Host=localhost;Port=5432;Database=PersonalAccountDb;Username=postgres;Password=password");
    
}