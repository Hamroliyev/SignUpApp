using SignUpApp.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUpApp.WPF.ViewModels.Factories
{
    public interface ISignUpViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
