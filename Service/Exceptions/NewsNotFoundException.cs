using System;

namespace Service.Exceptions
{
    /// <summary>
    /// Exception to be thrown when news that user is trying to access is not found
    /// </summary>
    [Serializable]
    public class NewsNotFoundException: Exception
    {
        public NewsNotFoundException(string message):
            base(message)
        { }
    }
}
