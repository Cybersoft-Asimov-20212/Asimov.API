using Asimov.API.Domain.Models;
using Asimov.API.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Asimov.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Director> Directors { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Director>().ToTable("Directors");
            builder.Entity<Director>().HasKey(p => p.Id);
            builder.Entity<Director>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Director>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<Director>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<Director>().Property(p => p.Age).IsRequired();
            builder.Entity<Director>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Entity<Director>().Property(p => p.Phone).IsRequired().HasMaxLength(30);

            builder.Entity<Director>()
                .HasMany(p => p.Announcements)
                .WithOne(p => p.Director)
                .HasForeignKey(p => p.DirectorId);
            
            builder.Entity<Director>()
                .HasMany(p => p.Teachers)
                .WithOne(p => p.Director)
                .HasForeignKey(p => p.DirectorId);
            
            // TODO: relación con teachers?
            
            builder.Entity<Director>().HasData(
                new Director
                {
                    Id = 1, FirstName = "Julio", LastName = "Salazar", Age = 22, Email = "julio@gmail.com",
                    Phone = "987654321"
                },
                new Director
                {
                    Id = 2, FirstName = "Yordy", LastName = "Mochcco", Age = 20, Email = "yordy@gmail.com",
                    Phone = "987654322"
                }
            );

            builder.Entity<Announcement>().ToTable("Announcements");
            builder.Entity<Announcement>().HasKey(p => p.Id);
            builder.Entity<Announcement>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Announcement>().Property(p => p.Title).IsRequired().HasMaxLength(30);
            builder.Entity<Announcement>().Property(p => p.Description).IsRequired().HasMaxLength(300);
            
            builder.Entity<Announcement>().HasData(
                new Announcement
                {
                    Id = 1, Title = "First Example title", Description = "Example description 1", DirectorId = 1
                },
                new Announcement
                {
                    Id = 2, Title = "Second Example title", Description = "Example description 2", DirectorId = 2
                },
                new Announcement
                {
                    Id = 3, Title = "Third Example title", Description = "Example description 3", DirectorId = 1
                },
                new Announcement
                {
                    Id = 4, Title = "Fourth Example title", Description = "Example description 4", DirectorId = 1
                },new Announcement
                {
                    Id = 5, Title = "Fifth Example title", Description = "Example description 5", DirectorId = 1
                },new Announcement
                {
                    Id = 6, Title = "Sixth Example title", Description = "Example description 6", DirectorId = 1
                },new Announcement
                {
                    Id = 7, Title = "Seventh Example title", Description = "Example description 7", DirectorId = 1
                },new Announcement
                {
                    Id = 8, Title = "Eighth Example title", Description = "Example description 8", DirectorId = 1
                }
                
            );
            // TODO: Teacher
            
            builder.Entity<Teacher>().ToTable("Teachers");
            builder.Entity<Teacher>().HasKey(p => p.Id);
            builder.Entity<Teacher>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Teacher>().Property(p => p.Point).IsRequired();
            builder.Entity<Teacher>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<Teacher>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<Teacher>().Property(p => p.Age).IsRequired();
            builder.Entity<Teacher>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Entity<Teacher>().Property(p => p.Phone).IsRequired().HasMaxLength(30);

            builder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1, FirstName = "Omar", LastName = "Alvarado", Age = 22, Email = "omar@gmail.com",
                    Phone = "987654321" , Point = 500 , DirectorId = 1
                },
                new Teacher
                {
                    Id = 2, FirstName = "Maria", LastName = "Vasquez", Age = 20, Email = "marifer@gmail.com",
                    Phone = "987654322" , Point = 400 , DirectorId = 1
                },
                new Teacher
                {
                    Id = 3, FirstName = "Julio", LastName = "Salazar", Age = 22, Email = "jul@gmail.com",
                    Phone = "987654321" , Point = 300 , DirectorId = 1
                },new Teacher
                {
                    Id = 4, FirstName = "Yordy", LastName = "Mochcco", Age = 22, Email = "yor@gmail.com",
                    Phone = "987654321" , Point = 420 , DirectorId = 1
                },new Teacher
                {
                    Id = 5, FirstName = "Rosa", LastName = "Gonzales", Age = 22, Email = "ros@gmail.com",
                    Phone = "987654321" , Point = 280 , DirectorId = 1
                },new Teacher
                {
                    Id = 6, FirstName = "Piero", LastName = "Perez", Age = 22, Email = "per@gmail.com",
                    Phone = "987654321" , Point = 340 , DirectorId = 1
                },new Teacher
                {
                    Id = 7, FirstName = "Juan", LastName = "Perez", Age = 22, Email = "jperz@gmail.com",
                    Phone = "987654321" , Point = 400 , DirectorId = 1
                },new Teacher
                {
                    Id = 8, FirstName = "Rodrigo", LastName = "Sabino", Age = 22, Email = "rod@gmail.com",
                    Phone = "987654321" , Point = 450 , DirectorId = 1
                },new Teacher
                {
                    Id = 9, FirstName = "Italo", LastName = "Canales", Age = 22, Email = "itsl@gmail.com",
                    Phone = "987654321" , Point = 520 , DirectorId = 1
                }
            );


            builder.Entity<Course>().ToTable("Courses");
            builder.Entity<Course>().HasKey(p => p.Id);
            builder.Entity<Course>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Course>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Course>().Property(p => p.Description).IsRequired().HasMaxLength(20);
            builder.Entity<Course>().Property(p => p.State).IsRequired();
            
            builder.Entity<Course>()
                .HasMany(p => p.Items)
                .WithOne(p => p.Course)
                .HasForeignKey(p => p.CourseId);

            builder.Entity<Course>().HasData(
                new Course
                {
                    // TODO: create enum for state Course 
                    Id = 1, Name = "Algebra", Description = "Course of 1st grade", State = false
                },
                new Course
                {
                    Id = 2, Name = "Trigonometry", Description = "Course of 2nd grade", State = false
                },
                new Course
                {
                    Id = 3, Name = "Biology", Description = "Course of 2nd grade", State = false
                },
                new Course
                {
                    Id = 4, Name = "Arithmetic", Description = "Course of 2nd grade", State = false
                },
                new Course
                {
                    Id = 5, Name = "Geography", Description = "Course of 2nd grade", State = false
                },
                new Course
                {
                    Id = 6, Name = "Universal history", Description = "Course of 2nd grade", State = false
                },
                new Course
                {
                    Id = 7, Name = "Physical", Description = "Course of 2nd grade", State = false
                },
                new Course
                {
                    Id = 8, Name = "Anatomy", Description = "Course of 2nd grade", State = false
                },
                new Course
                {
                    Id = 9, Name = "chemistry", Description = "Course of 2nd grade", State = false
                }
            );
            
            
            builder.Entity<Item>().ToTable("Items");
            builder.Entity<Item>().HasKey(p => p.Id);
            builder.Entity<Item>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Item>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Item>().Property(p => p.Value).IsRequired();
            builder.Entity<Item>().Property(p => p.State).IsRequired();
            
            builder.Entity<Item>().HasData(
                new Item
                {
                    // TODO: create enum for state Item 
                    Id = 1, Name = "Video", Value = "https://www.youtube.com/embed/LwCRRUa8yTU", 
                    State = false, CourseId = 1
                },
                new Item
                {
                    Id = 2, Name = "Documentation", Value = "Today we start with the theorem of...", 
                    State = false, CourseId = 2
                }
            );


            builder.Entity<TeacherCourse>().ToTable("TeacherCourses");
            builder.Entity<TeacherCourse>().HasKey(p => new {p.TeacherId, p.CourseId});
            builder.Entity<TeacherCourse>().Property(p => p.TeacherId).IsRequired();
            builder.Entity<TeacherCourse>().Property(p => p.CourseId).IsRequired();

            builder.Entity<TeacherCourse>()
                .HasOne(p => p.Teacher)
                .WithMany(p => p.TeacherCourses)
                .HasForeignKey(p => p.TeacherId);
            builder.Entity<TeacherCourse>()
                .HasOne(p => p.Course)
                .WithMany(p => p.TeacherCourses)
                .HasForeignKey(p => p.CourseId);

            builder.Entity<TeacherCourse>().HasData(
                new TeacherCourse {TeacherId = 1, CourseId = 1},
                new TeacherCourse {TeacherId = 1, CourseId = 2},
                new TeacherCourse {TeacherId = 2, CourseId = 3},
                new TeacherCourse {TeacherId = 2, CourseId = 4},
                new TeacherCourse {TeacherId = 2, CourseId = 5},
                new TeacherCourse {TeacherId = 2, CourseId = 6},
                new TeacherCourse {TeacherId = 2, CourseId = 7},
                new TeacherCourse {TeacherId = 2, CourseId = 8},
                new TeacherCourse {TeacherId = 2, CourseId = 9}
            );
            
            
            builder.UseSnakeCaseNamingConvention();
        }
    }
}