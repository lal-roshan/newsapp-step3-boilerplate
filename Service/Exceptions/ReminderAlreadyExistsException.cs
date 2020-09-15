using System;

namespace Service.Exceptions
{
    [Serializable]
    public class ReminderAlreadyExistsException: Exception
    {
        public ReminderAlreadyExistsException(string message):
            base(message)
        { }
    }
}
