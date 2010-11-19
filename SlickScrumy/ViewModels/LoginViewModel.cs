using System;
using System.ComponentModel;
using System.Reflection;
using SlickScrumy.Service;
using SlickScrumy.Utility;

namespace SlickScrumy.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string username;
        public string Username
        {
            get { return username; }
            set { Change("Username", value); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { Change("Password", value); }
        }

        private Command login;
        public Command Login
        {
            get
            {
                if (login == null)
                    login = new Command(
                        o => RunLogin(),
                        o => !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password));

                return login;
            }
        }

        private void RunLogin()
        {
            LoginDetails.User = Username;
            LoginDetails.Password = Password;
            if (LoginRequested != null)
                LoginRequested(this, EventArgs.Empty);
        }

        private void Change(string property, object value)
        {
            var fieldInfo = GetType().GetField(property.ToLower(), BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic);
            fieldInfo.SetValue(this, value);

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));

            Login.OnCanExecuteChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler LoginRequested;
    }
}