using MyLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLab2.Cmds
{
	public class AddTestCommand : CommandBase
	{
		public override bool CanExecute(object parameter)
		{
			return parameter != null && parameter is ObservableCollection<Test>;
		}

		public override void Execute(object parameter)
		{
			if(parameter is ObservableCollection<Test> tests)
			{
				//tests?.Add()
			}
		}
	}
}
