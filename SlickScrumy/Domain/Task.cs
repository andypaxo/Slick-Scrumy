using System;

namespace SlickScrumy.Domain
{
    public class Task
    {
        public const string ToDoState = "todo";
        public const string InProgressState = "inprogress";
        public const string ToVerifyState = "verify";
        public const string DoneState = "done";
        public string Title { get; set; }
        public string State { get; set; }
    }
}