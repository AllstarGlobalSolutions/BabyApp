using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;

namespace AGS.Toolkit
{
	class BoolToColorConverter
	{
		public Color TrueColor { get; set; }
		public Color FalseColor { get; set; }

		public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
		{
			return ( bool )value ? TrueColor : FalseColor;
		}

		public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
		{
			return false;
		}
	}
}
