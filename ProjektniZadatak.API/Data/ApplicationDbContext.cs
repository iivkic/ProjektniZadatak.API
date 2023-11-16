using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProjektniZadatak.API.Models.Domain;
using System.Security.Cryptography.X509Certificates;
namespace ProjektniZadatak.API.Data
{
    
    public class ApplicationDbContext : DbContext
    {
        

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public string DbPath { get; }

        public ApplicationDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "school.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           
            modelBuilder.Entity<Student>()
                .HasOne(e => e.Teacher)
                .WithMany(e => e.Students)
                .HasForeignKey(e => e.TeacherId);

            modelBuilder.Entity<Subject>()
                .HasOne(e => e.Student)
                .WithMany(e => e.Subjects)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Subject>()
                  .HasOne(e => e.Teacher)
                  .WithMany(e => e.Subjects)
                  .HasForeignKey(e => e.TeacherId);

            modelBuilder.Entity<Grade>()
                .HasOne(e => e.Subject)
                .WithMany(e => e.Grades)
                .HasForeignKey(e => e.SubjectId);

            
        }

        

        

        

    }
}
