using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;

namespace AGS.Toolkit
{
	[ContentProperty( "Ittems" )]
	public class ObjectToIndexConverter<T> : IValueConverter
	{
		public IList<T> Items { get; set; }

		public ObjectToIndexConverter()
		{
			Items = new List<T>();
		}

		public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
		{
			if ( value == null || !( value is T ) || Items == null )
			{
				return -1;
			}

			return Items.IndexOf( ( T )value );
		}

		public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
		{
			int index = ( int )value;

			if ( index < 0 || Items == null || index >= Items.Count )
			{
				return null;
			}

			return Items[ index ];
		}
	}
}
