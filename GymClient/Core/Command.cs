using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GymClient.Core
{
    public class Command : Command<object>
    {
        public Command(Action execute) : this(arg => execute()) { }

        public Command(Action<object> execute) : base(execute, can => true) { }

        public Command(Action execute, Predicate<object> canExecute) : base(arg => execute(), canExecute) { }

        public Command(Action execute, Func<bool> canExecute) : base(arg => execute(), arg => canExecute()) { }

        public Command(Action<object> execute, Func<bool> canExecute) : base(execute, arg => canExecute()) { }
    }

    public class Command<P> : ICommand
    {
        public Predicate<object> CanExecuteDelegate { get; set; }
        public Action<P> ExecuteDelegate { get; set; }

        public Command(Action execute) : this(arg => execute()) { }

        public Command(Action<P> execute) : this(execute, can => true) { }

        public Command(Action execute, Predicate<object> canExecute) : this(arg => execute(), canExecute) { }

        public Command(Action execute, Func<bool> canExecute) : this(arg => execute(), arg => canExecute()) { }

        public Command(Action<P> execute, Func<bool> canExecute) : this(execute, arg => canExecute()) { }

        public Command(Action<P> execute, Predicate<object> canExecute)
        {
            ExecuteDelegate = execute;
            CanExecuteDelegate = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteDelegate != null)
            {
                return CanExecuteDelegate(parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            Execute((P)parameter);
        }

        public void Execute(P parameter)
        {
            if (ExecuteDelegate != null)
            {
                ExecuteDelegate(parameter);
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
