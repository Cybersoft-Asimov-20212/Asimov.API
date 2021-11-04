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
                    Id = 2, FirstName = "Yordy", LastName = "Moccho", Age = 20, Email = "yordy@gmail.com",
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
                    Id = 2, FirstName = "Marifer", LastName = "Vasquez", Age = 20, Email = "marifer@gmail.com",
                    Phone = "987654322" , Point = 400 , DirectorId = 1
                }
            );
            
            
            builder.UseSnakeCaseNamingConvention();
        }
    }
}