using System;

namespace Service.Exceptions
{
    [Serializable]
    public class NewsAlreadyExistsException : Exception
    {
        public NewsAlreadyExistsException(string message) : base(message) { }
    }
}
