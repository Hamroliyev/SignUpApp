    using SignUpApp.WPF.Commands;
using SignUpApp.WPF.State.Authenticators;
using SignUpApp.WPF.State.Navigators;
using System.Windows.Input;

namespace SignUpApp.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public MessageViewModel ErrorMessageViewModel { get; }
        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ICommand LoginCommand { get; }
        public ICommand ViewRegisterCommand { get; }
        public LoginViewModel(IAuthenticator authenticator, IRenavigator loginRenavigator, IRenavigator registerRenavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();

            LoginCommand = new LoginCommand(this, authenticator, loginRenavigator);
            ViewRegisterCommand = new RenavigateCommand(registerRenavigator);
        }
    }
}
