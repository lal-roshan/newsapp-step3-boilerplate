using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Exceptions
{
    [Serializable]
    public class NewsNotFoundException: Exception
    {
        public NewsNotFoundException(string message):
            base(message)
        { }
    }
}
