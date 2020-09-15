using Entities;
using Microsoft.EntityFrameworkCore;
namespace DAL
{
    //Inherit DbContext class and use Entity Framework Code First Approach
    public class NewsDbContext: DbContext
    {
        public DbSet<UserProfile> Users { get; set; }

        public DbSet<News> NewsList { get; set; }

        public DbSet<Reminder> Reminders { get; set; }

        public NewsDbContext(DbContextOptions<NewsDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().HasKey(u => u.UserId);
            modelBuilder.Entity<UserProfile>().Property(u => u.UserId).ValueGeneratedNever();
            modelBuilder.Entity<UserProfile>().Property(u => u.UserId).IsRequired();
            modelBuilder.Entity<UserProfile>().Property(u => u.FirstName).IsRequired();
            modelBuilder.Entity<UserProfile>().Property(u => u.Email).IsRequired();
            modelBuilder.Entity<UserProfile>().Property(u => u.Contact).IsRequired();
            modelBuilder.Entity<UserProfile>().Property(u => u.CreatedAt).IsRequired();

            modelBuilder.Entity<News>().HasKey(n => n.NewsId);
            modelBuilder.Entity<News>().Property(n => n.NewsId).ValueGeneratedNever();
            modelBuilder.Entity<News>().Property(n => n.NewsId).IsRequired();
            modelBuilder.Entity<News>().Property(n => n.Title).IsRequired();
            modelBuilder.Entity<News>().Property(n => n.Content).IsRequired();
            modelBuilder.Entity<News>().Property(n => n.PublishedAt).IsRequired();
            modelBuilder.Entity<News>().Property(n => n.CreatedBy).IsRequired();
            modelBuilder.Entity<News>().Property(n => n.Url).IsRequired();
            modelBuilder.Entity<News>().Property(n => n.UrlToImage).IsRequired();

            modelBuilder.Entity<Reminder>().HasKey(r => r.ReminderId);
            //modelBuilder.Entity<Reminder>().Property(r => r.ReminderId).ValueGeneratedNever();
            modelBuilder.Entity<Reminder>().Property(r => r.ReminderId).IsRequired();
            modelBuilder.Entity<Reminder>().Property(r => r.Schedule).IsRequired();
            modelBuilder.Entity<Reminder>().Property(r => r.NewsId).IsRequired();
        }
        /*
        This class should be used as DbContext to speak to database and should make the use of 
        Code First Approach. It should autogenerate the database based upon the model class in 
        your application
        */

        //Create a Dbset for News,USerProfile and Reminders

        /*Override OnModelCreating function to configure relationship between entities and initialize*/
    }
}

