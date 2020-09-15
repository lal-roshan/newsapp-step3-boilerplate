using System;

namespace Service.Exceptions
{
    /// <summary>
    /// Exception to be thrown when the user profile that the user tries to access is not found 
    /// </summary>
    public class UserNotFoundException: Exception
    {
        public UserNotFoundException(string message):
            base(message)
        { }
    }
}
