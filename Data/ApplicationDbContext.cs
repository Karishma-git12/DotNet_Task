using Developer_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace Developer_Task.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Language> Languages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Subjects
            modelBuilder.Entity<Subject>().HasData(
             new Subject { Id = 1, Name = "Mathematics", StudentClassId = 1, LanguageId = 1 },
             new Subject { Id = 2, Name = "Physics", StudentClassId = 2, LanguageId = 2 },
             new Subject { Id = 3, Name = "Chemistry", StudentClassId = 3, LanguageId = 3 }
 );

            // Seed data for StudentClasses
            modelBuilder.Entity<StudentClass>().HasData(
                new StudentClass { Id = 1, Name = "First" },
                new StudentClass { Id = 2, Name = "Second" },
                new StudentClass { Id = 3, Name = "Third" }
            );

            // Seed data for Languages
            modelBuilder.Entity<Language>().HasData(
                new Language { Id = 1,Name = "English" },
                new Language { Id = 2,Name = "French" },
                new Language { Id = 3,Name = "Spanish" }
            );
        }

    }
   
}
