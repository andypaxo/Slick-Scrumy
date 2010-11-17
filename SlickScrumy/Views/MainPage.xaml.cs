using System.Windows.Controls;
using System.Windows.Navigation;

namespace SlickScrumy.Views
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // If an error occurs during navigation, show an error window
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            e.Handled = true;
            ChildWindow errorWin = new ChildWindow{Content = new TextBlock{Text = e.Exception.ToString()}};
            errorWin.Show();
        }
    }
}
