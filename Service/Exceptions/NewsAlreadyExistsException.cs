using System;

namespace Service.Exceptions
{
    /// <summary>
    /// Exception to be thrown when adding a news that already exists
    /// </summary>
    [Serializable]
    public class NewsAlreadyExistsException : Exception
    {
        public NewsAlreadyExistsException(string message) : base(message) { }
    }
}
