using SignUpApp.Domain.Models;
using SignUpApp.Domain.Services.AuthenticationServices;
using SignUpApp.WPF.State.Accounts;
using System;
using System.Threading.Tasks;

namespace SignUpApp.WPF.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountStore _accountStore;

        public Authenticator(IAuthenticationService authenticationService, IAccountStore accountStore)
        {
            _authenticationService = authenticationService;
            _accountStore = accountStore;
        }

        public Account CurrentAccount
        {
            get
            {
                return _accountStore.CurrentAccount;
            }
            private set
            {
                _accountStore.CurrentAccount = value;
                StateChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentAccount != null;

        public event Action StateChanged;

        public async Task Login(string userName, string password)
        {
            CurrentAccount = await _authenticationService.Login(userName, password);
        }

        public void Logout()
        {
            CurrentAccount = null;
        }

        public async Task<RegistrationResult> Register(string email, string userName, string password, string confirmPassword)
        {
            return await _authenticationService.Register(email, userName, password, confirmPassword);
        }
    }
}
