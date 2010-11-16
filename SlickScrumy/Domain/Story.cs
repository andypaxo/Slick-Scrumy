using System;
using System.Collections.Generic;
using System.Linq;

namespace SlickScrumy.Domain
{
    public class Story
    {
        public string Title { get; set; }
        public IEnumerable<Task> Tasks { get; set; }

        public IEnumerable<Task> TasksToDo
        {
            get { return Tasks.Where(x => x.State == Task.ToDoState); }
        }

        public IEnumerable<Task> TasksInProgress
        {
            get { return Tasks.Where(x => x.State == Task.InProgressState); }
        }

        public IEnumerable<Task> TasksToVerify
        {
            get { return Tasks.Where(x => x.State == Task.ToVerifyState); }
        }

        public IEnumerable<Task> TasksDone
        {
            get { return Tasks.Where(x => x.State == Task.DoneState); }
        }
    }
}