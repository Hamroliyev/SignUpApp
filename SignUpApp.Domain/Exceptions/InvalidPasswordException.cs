using System;

namespace SimpleTrader.Domain.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public InvalidPasswordException(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public InvalidPasswordException(string message, string userName, string password) : base(message)
        {
            UserName = userName;
            Password = password;
        }

        public InvalidPasswordException(string message, Exception innerException, string userName, string password) : base(message, innerException)
        {
            UserName = userName;
            Password = password;
        }
    }
}
