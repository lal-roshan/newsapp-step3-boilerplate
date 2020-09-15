using System;

namespace Service.Exceptions
{
    /// <summary>
    /// Exception to be thrown if the reminder that the user is trying to access is not found
    /// </summary>
    public class ReminderNotFoundException : Exception
    {
        public ReminderNotFoundException(string message) : base(message) { }
    }
}
