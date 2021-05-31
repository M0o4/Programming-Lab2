using MyLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfLab2.Cmds;
using WpfLab2.MVVM.Models;

namespace WpfLab2.MVVM.ViewModels
{
	public partial class AddTestViewModel : INotifyPropertyChanged
	{
		public string Name { get; set; }
		public string Text { get; set; }
		public string Answer { get; set; }
		public string WrongAnswers { get; set; }


		public event PropertyChangedEventHandler PropertyChanged;
		public IList<Test> Tests { get; }

		private RelayCommand _addTestCommand = null;

		public RelayCommand AddTestCmd
			=> _addTestCommand ?? (_addTestCommand = new RelayCommand(AddTest, CanAddTest));

		public AddTestViewModel()
		{
			Tests = Invenory.Tests;
		}

		private bool CanAddTest() => Tests != null && !_hasError;

		private void AddTest()
		{
			Test test = new Test {TestName = Name};
			test.AddTestQuestion(new TestQuestion(Text, Answer,new List<string>(Invenory.SplitWithComma(WrongAnswers))));
			Tests.Add(test);
			MessageBox.Show($"Added test {test.TestName}!");
		}

		//protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
		//{
		//	PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		//}
	}
}
