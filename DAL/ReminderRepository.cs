using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace DAL
{
    //Inherit the respective interface and implement the methods in 
    // this class i.e ReminderRepository by inheriting IReminderRepository
    //ReminderRepository class is used to implement all Data access operations
    public class ReminderRepository
    {
        public ReminderRepository(NewsDbContext dbContext)
        {
           
        }
        // Implement CreateReminder method which should be used to save a new reminder.    
        // Implement DeletReminder method which method should be used to delete an existing reminder.
        // Implement GetAllRemindersByUserId method which should be used to get all reminder by userId.
        // Implement GetReminderById method which should be used to get a reminder by reminderId
        // Implement UpdateReminder method which should be used to update an existing reminder

    }
}
