using SignUpApp.WPF.State.Navigators;
using SignUpApp.WPF.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace SignUpApp.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly ISignUpViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, ISignUpViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;

                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}
