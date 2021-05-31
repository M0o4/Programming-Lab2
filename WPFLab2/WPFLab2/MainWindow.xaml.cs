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

namespace WpfLab2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindowViewModel ViewModel { get; set; } = new MainWindowViewModel();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void ShowAddButtons(object sender, RoutedEventArgs e)
		{
			if(AddButtons.Visibility == Visibility.Collapsed)
			{
				AddButtons.Visibility = Visibility.Visible;
			}
			else
			{
				AddButtons.Visibility = Visibility.Collapsed;
			}
		}

		private async void Window_LoadedAsync(object sender, RoutedEventArgs e)
		{
			MVVM.Models.Invenory.Tests = new ObservableCollection<MyLibrary.Test>(await LoadData());
			//ListOfTestsViewModel.Tests = (ObservableCollection<MyLibrary.Test>)MVVM.Models.Invenory.Tests;
		}

		private async Task<List<MyLibrary.Test>> LoadData()
		{
			return await MVVM.Models.Invenory.
					DeserializeElement<List<MyLibrary.Test>>(MVVM.Models.Invenory.DefaultPathToFile) ?? new List<MyLibrary.Test>();
		}
	}
}
