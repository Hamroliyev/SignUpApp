using SignUpApp.WPF.State.Authenticators;
using SignUpApp.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SignUpApp.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;

        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(INavigator navigator, IAuthenticator authenticator)
        {
            _navigator = navigator;
            _authenticator = authenticator;

            _navigator.StateChanged += Navigator_StateChanged;
            _authenticator.StateChanged += Authenticator_StateChanged;
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
