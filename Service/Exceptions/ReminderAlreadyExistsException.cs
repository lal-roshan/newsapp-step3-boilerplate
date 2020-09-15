using System;

namespace Service.Exceptions
{
    /// <summary>
    /// Exception to be thrown when adding a reminder that already exists
    /// </summary>
    [Serializable]
    public class ReminderAlreadyExistsException: Exception
    {
        public ReminderAlreadyExistsException(string message):
            base(message)
        { }
    }
}
