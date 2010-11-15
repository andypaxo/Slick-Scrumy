using System;
using System.Windows.Controls;
using SlickScrumy.Service;

namespace SlickScrumy.Views
{
    public partial class MainPage : UserControl
    {
        private TaskBoardView taskBoardView;

        public MainPage()
        {
            InitializeComponent();
        }

        private void uxLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private void LoginForm_LoginRequested(object sender, LoginEventArgs e)
        {
            LayoutRoot.Children.Clear();
            taskBoardView = new TaskBoardView();
            LayoutRoot.Children.Add(taskBoardView);

            var taskBoardService = new TaskBoardService();
            taskBoardService.FetchCompleted += OnServiceFetchCompleted;
            taskBoardService.FetchSprint(e.Username, e.Password);
        }

        void OnServiceFetchCompleted(object sender, FetchSprintEventArgs e)
        {
            taskBoardView.SetSprint(e.Sprint);
        }
    }
}
