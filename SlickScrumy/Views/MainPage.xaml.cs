using System.Windows.Controls;
using SlickScrumy.Service;

namespace SlickScrumy.Views
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void uxLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var sprint = new TaskBoardService().FetchSprint(uxUsername.Text, uxPassword.Text);
            LayoutRoot.Children.Add(new TaskBoardView {DataContext = sprint});
        }
    }
}
