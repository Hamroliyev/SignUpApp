using Microsoft.AspNet.Identity;
using SignUpApp.Domain.Exceptions;
using SignUpApp.Domain.Models;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SignUpApp.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<Account> Login(string userName, string password)
        {
            Account storedAccount = await _accountService.GetByUsername(userName);

            if (storedAccount == null)
            {
                throw new UserNotFoundException(userName);
            }

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedAccount.AccountHolder.PasswordHash, password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(userName, password);
            }

            return storedAccount;
        }

        public bool IsValidPassword(string plainText)
        {
            Regex regex = new Regex(@"^(.{0,7}|[^0-9]*|[^A-Z])$");
            Match match = regex.Match(plainText);
            return match.Success;
        }
        public static bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        public bool IsValidEmail(string plainText)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(plainText);
            return match.Success;
        }

        public async Task<RegistrationResult> Register(string email, string userName, string password, string confirmPassword)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (!isValidEmail(email))
            {
                result = RegistrationResult.InvalidEmail;
                return result;
            }

            if (IsValidPassword(password))
            {
                result = RegistrationResult.InvalidPassword;
                return result;
            }

            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordsDoNotMatch;
                return result;
            }

            Account emailAccount = await _accountService.GetByEmail(email);
            if (emailAccount != null)
            {
                result = RegistrationResult.EmailAlreadyExists;
            }

            Account usernameAccount = await _accountService.GetByUsername(userName);
            if (usernameAccount != null)
            {
                result = RegistrationResult.UserNameAlreadyExists;
            }

            if (result == RegistrationResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);

                User user = new User()
                {
                    Email = email,
                    Username = userName,
                    PasswordHash = hashedPassword,
                    DateJoined = DateTime.Now
                };

                Account account = new Account()
                {
                    AccountHolder = user
                };

                await _accountService.Create(account);
            }

            return result;
        }
    }
}
