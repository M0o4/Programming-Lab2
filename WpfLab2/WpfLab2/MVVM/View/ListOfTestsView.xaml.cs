using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfLab2.MVVM.ViewModels;

namespace WpfLab2.MVVM.View
{
	/// <summary>
	/// Interaction logic for ListOfTestsView.xaml
	/// </summary>
	public partial class ListOfTestsView : UserControl
	{
		public ListOfTestsViewModel ViewModel { get; set; } = new ListOfTestsViewModel();
		public ListOfTestsView()
		{
			InitializeComponent();
		}

		private void UserControl_LoadedAsync(object sender, RoutedEventArgs e)
		{
			ViewModel.Tests = (ObservableCollection<MyLibrary.Test>)Models.Invenory.Tests;
		}

		private async Task<List<MyLibrary.Test>> LoadData()
		{
			return await Models.Invenory.
					DeserializeElement<List<MyLibrary.Test>>(Models.Invenory.DefaultPathToFile) ?? new List<MyLibrary.Test>();
		}
	}
}
