using System.Windows;
using System.Windows.Controls;

namespace SignUpApp.WPF.Views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void checker_Checked(object sender, RoutedEventArgs e)
        {
            Password.Visibility = Visibility.Hidden;
            passwordTxtBox.Visibility = Visibility.Visible;
            passwordTxtBox.Text = Password.Password.ToString();
        }

        private void checker_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordTxtBox.Visibility = Visibility.Hidden;
            Password.Visibility = Visibility.Visible;
        }
    }
}
