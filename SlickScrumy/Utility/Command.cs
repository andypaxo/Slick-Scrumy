using System;
using System.Windows.Input;

namespace SlickScrumy.Utility
{
    public class Command : ICommand
    {
        private Action<object> command;
        private Func<object, bool> canExecute;

        public Command(Action<object> command, Func<object, bool> canExecute)
        {
            this.command = command;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            command(parameter);
        }

        public void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}