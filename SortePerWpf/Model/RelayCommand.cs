using System;
using System.Windows.Input;

namespace SortePerWpf.Model
{
    public class RelayCommand : ICommand
    {
        // The action for the command
        private Action<object> _method;

        // The prediction if the command can be executed
        private Predicate<object> _canExe;

        /// <summary>
        /// Construct the relay command, takes in a method with no parameters
        /// and takes in whether the command can get executed
        /// </summary>
        /// <param name="_ex"></param>
        /// <param name="_canE"></param>
        public RelayCommand(Action<object> _ex, Predicate<object> _canE)
        {
            if (_ex == null)
                throw new ArgumentException("Execute");

            _method = _ex;
            _canExe = _canE;
        }

        /// <summary>
        /// Construct the relay command, takes in a method with no parameters
        /// </summary>
        /// <param name="_ex"></param>
        public RelayCommand(Action<object> _ex) : this(_ex, null)
        {

        }

        /// <summary>
        /// called when the can execute parameter changes condition
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Whether the command can be executed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return (_canExe == null) ? true : _canExe(parameter);
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _method(parameter);
        }
    }
}
