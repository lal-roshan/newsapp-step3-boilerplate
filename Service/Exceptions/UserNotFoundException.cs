using System;

namespace Service.Exceptions
{
    public class UserNotFoundException: Exception
    {
        public UserNotFoundException(string userId):
            base($"{userId} doesn't exist")
        { }
    }
}
