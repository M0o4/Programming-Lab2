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
	public class AddChallengeViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public string Name { get; set; }
		public string Text { get; set; }
		public string Answer { get; set; }
		public string WrongAnswers { get; set; }
		public string NameOfEducationalInstitution { get; set; }
		public string PassingScore { get; set; }

		public IList<Test> Tests { get; }

		private RelayCommand _addTestCommand = null;

		public RelayCommand AddTestCmd
			=> _addTestCommand ?? (_addTestCommand = new RelayCommand(AddTest, CanAddTest));

		public AddChallengeViewModel()
		{
			Tests = Invenory.Tests;
		}

		private bool CanAddTest() => Tests != null;

		private void AddTest()
		{
			Challenge challenge = new Challenge();
			challenge.TestName = Name;
			challenge.NameOfEducationalInstitution = NameOfEducationalInstitution;
			challenge.PassingScore = int.Parse(PassingScore);

			challenge.AddTestQuestion(new TestQuestion(Text, Answer, new List<string>(Invenory.SplitWrongAnswers(WrongAnswers))));

			MessageBox.Show($"Added test {challenge.TestName}!");
			Tests.Add(challenge);
		}
	}
}
