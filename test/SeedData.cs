using Entities;
using DAL;
using System;

namespace Test
{
    public static class SeedData
    {
        public static void PopulateTestData(NewsDbContext context)
        {
            AddUsers(context);
            AddNews(context);
            AddReminders(context);
        }

        private static void AddUsers(NewsDbContext context)
        {
            context.Users.Add(new UserProfile { UserId = "Jack", FirstName = "Jackson",LastName="James", Contact = "9812345670", Email="jack@ymail.com", CreatedAt=DateTime.Now });
            context.SaveChanges();
        }

        private static void AddNews(NewsDbContext context)
        {
            context.NewsList.Add(new News { NewsId = 101, Title = "IT industry in 2020", Content = "It is expected to have positive growth in 2020.", PublishedAt = DateTime.Now, UrlToImage = null, CreatedBy = "Jack", Url=null });
            context.NewsList.Add(new News {NewsId=102, Title = "2020 FIFA U-17 Women World Cup", Content = "The tournament will be held in India between 2 and 21 November 2020", PublishedAt = DateTime.Now, UrlToImage=null, CreatedBy = "Jack" });
            context.SaveChanges();
        }
        private static void AddReminders(NewsDbContext context)
        {
            context.Reminders.Add(new Reminder { NewsId=101, Schedule=DateTime.Now.AddDays(5) });
            context.SaveChanges();
        }
       
    }
}
