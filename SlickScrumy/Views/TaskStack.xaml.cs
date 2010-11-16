using System;
using System.Collections.Generic;
using System.Windows.Controls;
using SlickScrumy.Domain;

namespace SlickScrumy.Views
{
    public partial class TaskStack : UserControl
    {
        private IEnumerable<Task> tasks;
        public IEnumerable<Task> Tasks
        {
            get { return tasks; }
            set {
                tasks = value;
                DataContext = tasks;
            }
        }

        public TaskStack()
        {
            InitializeComponent();
        }
    }
}
