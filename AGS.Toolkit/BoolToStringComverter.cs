using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;

namespace AGS.Toolkit
{
	public class BoolToStringComverter : IValueConverter
	{
		public string TrueText { get; set; }
		public string FalseText { get; set; }

		public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
		{
			return ( bool )value ? TrueText : FalseText;
		}

		public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
		{
			return false;
		}
	}
}
