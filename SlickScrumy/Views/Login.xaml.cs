using System;
using SlickScrumy.ViewModels;

namespace SlickScrumy.Views
{
    public partial class Login
    {
        private readonly LoginViewModel viewModel = new LoginViewModel();

        public Login()
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.LoginRequested += OnLoginRequested;
        }

        void OnLoginRequested(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/TaskBoard", UriKind.Relative));
        }
    }
}
