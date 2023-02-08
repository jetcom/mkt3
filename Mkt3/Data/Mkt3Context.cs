using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mkt3.Data;

public class Mkt3Context: DbContext
{
    public DbSet<Exam> Exams { get; set; }
    public DbSet<QuestionTopic> QuestionTopics { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Group> Groups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(@"Host=localhost;Username=mkt;Password=mkt3;Database=mkt");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    
        modelBuilder.Entity<Exam>()
            .HasKey(nameof(Exam.examID), nameof(Exam.courseNumber));
        modelBuilder.Entity<QuestionTopic>()
            .HasKey(nameof(QuestionTopic.QuestionID), nameof(QuestionTopic.TopicID));
    }
    
    public Mkt3Context(DbContextOptions<Mkt3Context> options)
        : base(options)
    {
    }
  
}