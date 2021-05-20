using System;
using System.Windows.Input;

namespace WpfLab2.Core
{
	class RelayCommand : ICommand
	{
		private Action<object> _execute;
		private Func<object, bool> _canExecute;

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

		public void Execute(object parameter) => _execute(parameter);

		public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}
	}
}
