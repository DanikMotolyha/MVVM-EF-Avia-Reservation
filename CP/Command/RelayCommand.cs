using System;
using System.Windows.Input;

namespace CP.Command
{
    class RelayCommand : ICommand
    {
        readonly Action<object> _execute;

        /// <summary>
        /// Проверка возможности выполнения функции
        /// </summary>
        readonly Predicate<object> _canexecute;

        public RelayCommand(Action<object> execute, Predicate<object> canexecute)
        {
            if (execute is null)
                throw new NullReferenceException("execute");

            _execute = execute;
            _canexecute = canexecute;
        }

        public RelayCommand(Action<object> execute) : this(execute, x => true)
        {

        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canexecute is null ? false : _canexecute(parameter);
        }

        public void Execute(object parameter = null)
        {
            _execute.Invoke(parameter);
        }

    }
}
