using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Mkt3.Data;

public class Mkt3Context: DbContext
{
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Question> Questions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(@"Host=localhost;Username=mkt;Password=mkt3;Database=mkt");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exam>()
            .HasKey(nameof(Exam.examID), nameof(Exam.courseNumber));
    }
  
}