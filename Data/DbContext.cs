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
   
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql("Host=localhost;Port=5432;Database=PersonalAccountDb;Username=postgres;Password=password");
    
}