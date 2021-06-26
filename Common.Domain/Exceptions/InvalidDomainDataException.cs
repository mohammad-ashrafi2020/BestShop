using System;

namespace Common.Domain.Exceptions
{
    public class InvalidDomainDataException:Exception
    {
        public string ErrorMessage { get; private set; }
        public InvalidDomainDataException(string message):base(message)
        {
            ErrorMessage = message;
        }

        public InvalidDomainDataException()
        {
            
        }
    }
}