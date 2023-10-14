using SignUpApp.WPF.State.Navigators;
using System;

namespace SignUpApp.WPF.ViewModels.Factories
{
    public class SignUpViewModelFactory : ISignUpViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;

        public SignUpViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel,
            CreateViewModel<LoginViewModel> createLoginViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createLoginViewModel = createLoginViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Home:
                    return _createHomeViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
