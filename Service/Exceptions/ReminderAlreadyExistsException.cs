using System;

namespace Service.Exceptions
{
    [Serializable]
    public class ReminderAlreadyExistsException: Exception
    {
        public ReminderAlreadyExistsException(int newsId):
            base($"This news: {newsId} already have a reminder")
        { }
    }
}
