using System;
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
            foreach (var story in sprint.Stories)
            {
                LayoutRoot.RowDefinitions.Add(new RowDefinition());
                var textBlock = new TextBlock
                {
                    Text = story.Title
                };
                Grid.SetColumn(textBlock, 0);
                Grid.SetRow(textBlock, LayoutRoot.RowDefinitions.Count - 1);
                LayoutRoot.Children.Add(textBlock);
            }
        }
    }
}
