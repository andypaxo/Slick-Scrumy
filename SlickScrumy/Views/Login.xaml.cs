using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using SlickScrumy.Service;

namespace SlickScrumy.Views
{
    [DefaultEvent("LoginRequested")]
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void uxLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginDetails.User = uxUsername.Text;
            LoginDetails.Password = uxPassword.Password;
            NavigationService.Navigate(new Uri("/TaskBoard", UriKind.Relative));
        }
    }
}
