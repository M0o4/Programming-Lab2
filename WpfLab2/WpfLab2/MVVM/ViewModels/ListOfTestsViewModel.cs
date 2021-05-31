using MyLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfLab2.Cmds;
using WpfLab2.MVVM.Models;

namespace WpfLab2.MVVM.ViewModels
{
	public class ListOfTestsViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public string SearchElementName { get; set; }
		public IList<Test> Tests { get; set; }

		private RelayCommand _saveListCommnad = null;
		public RelayCommand SaveListCmd
			=> _saveListCommnad ?? (_saveListCommnad = new RelayCommand(SaveList, CanSaveList));

		private RelayCommand _deleteFileCommand = null;
		public RelayCommand DeleteFileCmd
			=> _deleteFileCommand ?? (_deleteFileCommand = new RelayCommand(DeleteFile, CanDeleteFile));

		private RelayCommand _findElementCommand = null;
		public RelayCommand FindElementCmd
			=> _findElementCommand ?? (_findElementCommand = new RelayCommand(FindElement, CanFindElement));

		private bool CanSaveList() => Tests != null && Tests.Count != 0;

		private async void SaveList()
		{
			var list = new List<Test>(Invenory.Tests);
			if (!(await Invenory.SerializeElement(Invenory.DefaultPathToFile, list)))
			{
				MessageBox.Show($"В процессе произошла ошибка");
			}
		}

		private bool CanDeleteFile() => Tests != null && Tests.Count != 0;

		private void DeleteFile()
		{
			File.Delete(Invenory.DefaultPathToFile);
			Invenory.Tests.Clear();
			Tests.Clear();
		}

		private bool CanFindElement() => Invenory.Tests != null && Invenory.Tests.Count != 0;

		private void FindElement()
		{
			var result = Invenory.Tests.Where(m => m.TestName.ToLower().
			  Contains(SearchElementName.ToLower())).ToList();
			Tests = new ObservableCollection<Test>(result);
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
	
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
