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
	public class AddFinalExamViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public string Name { get; set; }
		public string Text { get; set; }
		public string Answer { get; set; }
		public string WrongAnswers { get; set; }
		public string Examiners { get; set; }
		public string TimeLimit { get; set; }

		public IList<Test> Tests { get; }

		private RelayCommand _addTestCommand = null;

		public RelayCommand AddTestCmd
			=> _addTestCommand ?? (_addTestCommand = new RelayCommand(AddTest, CanAddTest));

		public AddFinalExamViewModel()
		{
			Tests = Invenory.Tests;
		}

		private bool CanAddTest() => Tests != null;

		private void AddTest()
		{
			FinalExam exam = new FinalExam();
			exam.TestName = Name;
			exam.TimeLimit = int.Parse(TimeLimit);
			exam.ListOfExaminers = new List<string>(Invenory.SpliWithComma(Examiners));

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
