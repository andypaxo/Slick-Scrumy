using System;

namespace SlickScrumy.Views
{
    public class LoginEventArgs : EventArgs
    {
        public LoginEventArgs(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
