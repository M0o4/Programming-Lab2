using System;
using WpfLab2.Core;

namespace WpfLab2.MVVM.ViewModel
{
	class MainViewModel : ObservableObject
	{
		public RelayCommand HomeViewCommand { get; set; }
		public RelayCommand DiscoveryViewCommand { get; set; }

		public HomeViewModel HomeVM { get; set; }
		public DiscoveryViewModel DiscoveryVM { get; set; }

		private object _currentView;

		public object CurrentView
		{
			get { return _currentView; }
			set 
			{ 
				_currentView = value;
				OnPropertyChanged();
			}
		}


		public MainViewModel()
		{
			HomeVM = new HomeViewModel();
			DiscoveryVM = new DiscoveryViewModel();
			CurrentView = HomeVM;

			HomeViewCommand = new RelayCommand(o => 
			{
				CurrentView = HomeVM;
			});

			DiscoveryViewCommand = new RelayCommand(o =>
			{
				CurrentView = DiscoveryVM;
			});
		}
	}
}
