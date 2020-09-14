using Entities;
using Microsoft.EntityFrameworkCore;
namespace DAL
{
    //Inherit DbContext class and use Entity Framework Code First Approach
    public class NewsDbContext
    {
        /*
        This class should be used as DbContext to speak to database and should make the use of 
        Code First Approach. It should autogenerate the database based upon the model class in 
        your application
        */

        //Create a Dbset for News,USerProfile and Reminders

        /*Override OnModelCreating function to configure relationship between entities and initialize*/
    }
}

