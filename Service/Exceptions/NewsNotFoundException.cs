using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Exceptions
{
    [Serializable]
    public class NewsNotFoundException: Exception
    {
        public NewsNotFoundException(string userId):
            base($"No news found for user: {userId}")
        { }

        public NewsNotFoundException(int newsId):
            base($"No news found with Id: {newsId}")
        { }
    }
}
