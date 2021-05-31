using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfLab2.MVVM.Models;

namespace WpfLab2.MVVM.ViewModels
{
	public partial class AddTestViewModel : EntityBase, IDataErrorInfo
	{
		private string _error;
		public string Error => _error;

		private bool _hasError;

		public string this[string columnName]
		{
			get
			{
				switch (columnName)
				{
					case nameof(Name):
						//AddErrors(nameof(Name), GetErrorsFromAnnotations(nameof(Name), Name));
						if (string.IsNullOrEmpty(Name))
						{
							_hasError = true;
							return "Введите название!";
						}
						break;
					case nameof(Text):
						if (string.IsNullOrEmpty(Text))
						{
							_hasError = true;
							return "Введите вопрос!";
						}
						break;
				}
				_hasError = false;
				return string.Empty;
			}
		}
	}
}
