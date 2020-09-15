using System;

namespace Service.Exceptions
{
    /// <summary>
    /// Exception to be thrown when adding a user that already exists
    /// </summary>
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string message) : base(message) { }
    }
}
