using System;
using SignUpApp.Domain.Exceptions;
using System.Threading.Tasks;
using SignUpApp.Domain.Models;

namespace SignUpApp.Domain.Services.AuthenticationServices
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
        UserNameAlreadyExists,
        InvalidPassword
    }
    public interface IAuthenticationService
    {
        Task<RegistrationResult> Register(string email, string userName, string password, string confirmPassword);
        /// <summary>
        /// Get account for a user's credentials.
        /// </summary>
        /// <param name="userName">The user's name</param>
        /// <param name="password">The user's password.</param>
        /// <returns>The account for the user.</returns>
        /// <exception cref="UserNotFoundException">Thrown if the user does not exist.</exception>
        /// <exception cref="InvalidPasswordException">Thrown if the password is invalid.</exception>
        /// <exception cref="Exception">Thrown if the login fails.</exception>
        Task<Account> Login(string userName, string password);
    }
}
