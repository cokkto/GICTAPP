using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace GICTAPP
{
    /// <summary>
    ///     Wrapper over ICommand interface to implement Execute and CanEecute functionality
    /// </summary>
    public class RelayCommand : ICommand
    { 
        private Predicate<object> _canExecute;
        private Action<object> _execute;

        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        { 
            this._canExecute = canExecute;
            this._execute = execute;
        }

        /// <summary>
        ///     Event to raise CanExecute on changes
        /// </summary>
        public event EventHandler CanExecuteChanged
        { 
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        ///     Evaluate posibility to execute command
        /// </summary>
        public bool CanExecute(object parameter)
        { 
            return _canExecute(parameter);
        }

        /// <summary>
        ///     Execute command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        { 
            _execute(parameter);
        }
    }
}
