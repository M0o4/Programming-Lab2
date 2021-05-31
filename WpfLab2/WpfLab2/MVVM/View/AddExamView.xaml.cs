using System;
using System.Collections.Generic;
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
	/// Interaction logic for AddExamView.xaml
	/// </summary>
	public partial class AddExamView : UserControl
	{
		public AddExamViewModel ViewModel { get; set; } = new AddExamViewModel();
		public AddExamView()
		{
			InitializeComponent();
		}
	}
}
