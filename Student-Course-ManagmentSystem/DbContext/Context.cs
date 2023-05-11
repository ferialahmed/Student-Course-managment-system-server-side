using System;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Options;

namespace Student_Course_ManagmentSystem.DataModels
{
    public class DataContext : DbContext
    {
      
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Grade>()
        .HasKey(g => new { g.StudentId, g.CourseId });

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Course)
                .WithMany(c => c.Grades)
                .HasForeignKey(g => g.CourseId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=student-course-managment-system;Integrated Security=True");

        }

    }
}
