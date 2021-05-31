using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfLab2.Cmds;
using WpfLab2.MVVM.Models;

namespace WpfLab2.MVVM.ViewModels
{
	public class AddExamViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public string Name { get; set; }
		public string Text { get; set; }
		public string Answer { get; set; }
		public string WrongAnswers { get; set; }

		public IList<Test> Tests { get; }

		private RelayCommand _addTestCommand = null;

		public RelayCommand AddTestCmd
			=> _addTestCommand ?? (_addTestCommand = new RelayCommand(AddTest, CanAddTest));

		public AddExamViewModel()
		{
			Tests = Invenory.Tests;
		}

		private bool CanAddTest() => Tests != null;

		private void AddTest()
		{
			Exam exam = new Exam();
			exam.TestName = Name;

			if (string.IsNullOrEmpty(WrongAnswers))
			{
				exam.AddWriteQuestion(new Question(Text, Answer));
			}
			else
			{
				exam.AddTestQuestion(new TestQuestion(Text, Answer, new List<string>(Invenory.SpliWithComma(WrongAnswers))));
			}

			MessageBox.Show($"Added test {exam.TestName}!");
			Tests.Add(exam);
		}
	}
}
