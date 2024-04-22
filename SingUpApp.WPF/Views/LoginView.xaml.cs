using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SignUpApp.WPF.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void checker_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordTxtBox.Visibility = Visibility.Hidden;
            Password.Visibility = Visibility.Visible;
        }

        private void checker_Checked(object sender, RoutedEventArgs e)
        {
            Password.Visibility = Visibility.Hidden;
            passwordTxtBox.Visibility = Visibility.Visible;
            passwordTxtBox.Text = Password.Password.ToString();
        }
    }
}
