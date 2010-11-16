using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SlickScrumy.Domain;

namespace SlickScrumy.Views
{
    public partial class TaskBoardView : UserControl
    {
        public TaskBoardView()
        {
            InitializeComponent();
        }

        public void SetSprint(Sprint sprint)
        {
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
