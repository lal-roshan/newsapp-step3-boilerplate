using System;

namespace Service.Exceptions
{
    [Serializable]
    public class NewsAlreadyExistsException : Exception
    {
        public NewsAlreadyExistsException() : base("This news is already added") { }
    }
}
