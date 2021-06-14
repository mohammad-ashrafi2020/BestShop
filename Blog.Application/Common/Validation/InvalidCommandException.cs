using System;

namespace Blog.Application.Common.Validation
{
    public class InvalidCommandException:Exception
    {
        public string Details { get; }
        public InvalidCommandException(string message,string details):base(message)
        {
            Details = details;
        }
    }
}