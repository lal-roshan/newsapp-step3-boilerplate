using DAL;
using Entities;
using Service.Exceptions;
using System.Threading.Tasks;

namespace Service
{
    //Inherit the respective interface and implement the methods in 
    // this class i.e ReminderService by inheriting IReminderService

    // ReminderService class is used to implement all input validation operations for Reminder CRUD operations

    public class ReminderService
    {
        /*
         * this service depends on ReminderRepository instance for the crud operations
         */



        /*
         * Implement AddReminder() method which should be used to 
         * save a new reminder, provided the reminder does not exist for the specific news id, 
         * else should throw ReminderAlreadyExistsException
         */

        /*
         * Implement GetReminderByNewsId() method which should be used to 
         * get complete reminder details for the provided newsId,
         * however, should throw ReminderNotFoundException if no reminder exist for the provided newsId
         */


        /*
         * Implement RemoveReminder() method which should be used to 
         * delete an existing reminder
         * however, should throw ReminderNotFoundException if reminder with provided reminderId does not exist         * 
         */

    }
}
