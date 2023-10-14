using SignUpApp.WPF.Commands;
using SignUpApp.WPF.State.Authenticators;
using SignUpApp.WPF.State.Navigators;
using SignUpApp.WPF.ViewModels.Factories;
using System.Windows.Input;

namespace SignUpApp.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ISignUpViewModelFactory _viewModelFactory;
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;

        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(INavigator navigator,ISignUpViewModelFactory viewModelFactory, IAuthenticator authenticator)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;

            _navigator.StateChanged += Navigator_StateChanged;
            _authenticator.StateChanged += Authenticator_StateChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }

        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
