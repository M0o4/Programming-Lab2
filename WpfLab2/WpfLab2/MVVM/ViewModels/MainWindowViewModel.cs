using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLab2.Cmds;

namespace WpfLab2.MVVM.ViewModels
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public object CurrentView { get; set; }

		public AddTestViewModel AddTestVM { get; set; }
		public ListOfTestsViewModel ListOfTestsVM { get; set; }
		public AddExamViewModel AddExamVM { get; set; }
		public AddFinalExamViewModel AddFinalExamVM { get; set; }
		public AddChallengeViewModel AddChallengeVM { get; set; }

		private RelayCommand _addTestCommand = null;
		public RelayCommand AddTestCmd => _addTestCommand ?? (_addTestCommand = new RelayCommand(() => { CurrentView = AddTestVM; }));

		private RelayCommand _listOfTestsCommand = null;
		public RelayCommand ListOfTestCmd
			=> _listOfTestsCommand ?? (_listOfTestsCommand = new RelayCommand(() => { CurrentView = ListOfTestsVM; }));

		private RelayCommand _addExamCommand = null;
		public RelayCommand AddExamCmd
			=> _addExamCommand ?? (_addExamCommand = new RelayCommand(() => { CurrentView = AddExamVM; }));

		private RelayCommand _addFinalExamCommand = null;
		public RelayCommand AddFinalExamCmd
			=> _addFinalExamCommand ?? (_addFinalExamCommand = new RelayCommand(() => { CurrentView = AddFinalExamVM; }));

		private RelayCommand _addChallengeCommand = null;
		public RelayCommand AddChallengeCmd
			=> _addChallengeCommand ?? (_addChallengeCommand = new RelayCommand(() => { CurrentView = AddChallengeVM; }));


		public MainWindowViewModel()
		{
			AddTestVM = new AddTestViewModel();
			ListOfTestsVM = new ListOfTestsViewModel();
			AddExamVM = new AddExamViewModel();
			AddFinalExamVM = new AddFinalExamViewModel();
			AddChallengeVM = new AddChallengeViewModel();
		}
	}
}
