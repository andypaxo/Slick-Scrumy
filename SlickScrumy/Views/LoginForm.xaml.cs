using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace SlickScrumy.Views
{
    [DefaultEvent("LoginRequested")]
    public partial class LoginForm : UserControl
    {
        public event EventHandler<LoginEventArgs> LoginRequested;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void uxLogin_Click(object sender, RoutedEventArgs e)
        {
            if (LoginRequested != null)
                LoginRequested(this, new LoginEventArgs(uxUsername.Text, uxPassword.Password));
        }
    }
}
