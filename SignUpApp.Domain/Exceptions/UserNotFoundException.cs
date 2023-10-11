using System;

namespace SimpleTrader.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string UserName { get; set; }
        public UserNotFoundException(string userName)
        {
            UserName = userName;
        }

        public UserNotFoundException(string message, string userName) : base(message)
        {
            UserName = userName;
        }

        public UserNotFoundException(string message, Exception innerException, string userName) : base(message, innerException)
        {
            UserName = userName;
        }
    }
}
