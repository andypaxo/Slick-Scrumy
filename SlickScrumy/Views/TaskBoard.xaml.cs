using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SlickScrumy.Domain;
using SlickScrumy.Service;

namespace SlickScrumy.Views
{
    public partial class TaskBoard : Page
    {
        public TaskBoard()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var taskBoardService = new TaskBoardService();
            taskBoardService.FetchCompleted += (o, ea) => SetSprint(ea.Sprint);
            taskBoardService.FetchSprint(LoginDetails.User, LoginDetails.Password);
        }

        private void SetSprint(Sprint sprint)
        {
            progressBar.Visibility = System.Windows.Visibility.Collapsed;

            var columns = new List<List<IEnumerable<Task>>>();
            columns.AddRange(Enumerable.Repeat(new List<IEnumerable<Task>>(), 4));

            foreach (var story in sprint.Stories)
            {
                AddRow();
                AddControl(new TextBlock { Text = story.Title, TextWrapping = TextWrapping.Wrap});
                AddControl(new TaskStack { Tasks = story.TasksToDo });
                AddControl(new TaskStack { Tasks = story.TasksInProgress });
                AddControl(new TaskStack { Tasks = story.TasksToVerify });
                AddControl(new TaskStack { Tasks = story.TasksDone });
            }
        }

        private int currentCol = 0;
        void AddRow()
        {
            currentCol = 0;
            LayoutRoot.RowDefinitions.Add(new RowDefinition());
        }

        void AddControl(FrameworkElement control)
        {
            Grid.SetColumn(control, currentCol++);
            Grid.SetRow(control, LayoutRoot.RowDefinitions.Count - 1);
            LayoutRoot.Children.Add(control);
        }
    }
}
