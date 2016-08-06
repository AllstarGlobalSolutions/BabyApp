using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Xamarin.Forms;

namespace AGS.Toolkit
{
	public class ColorViewModel : INotifyPropertyChanged
	{
		Color color;

		public event PropertyChangedEventHandler PropertyChanged;

		public double Red
		{
			get
			{
				return Round( color.R );
			}
			set
			{
				if ( Round( color.R ) != value )
				{
					Color = Color.FromRgba( value, color.G, color.B, color.A );
				}
			}
		}

		public double Green
		{
			get
			{
				return Round( color.G );
			}
			set
			{
				if ( Round( color.G ) != value )
				{
					Color = Color.FromRgba( color.R, value, color.B, color.A );
				}
			}
		}

		public double Blue
		{
			get
			{
				return Round( color.B );
			}
			set
			{
				if ( Round( color.B ) != value )
				{
					Color = Color.FromRgba( color.R, color.G, value, color.A );
				}
			}
		}

		public double Alpha
		{
			get
			{
				return Round( color.A );
			}
			set
			{
				if ( Round( color.A ) != value )
				{
					Color = Color.FromRgba( color.R, color.G, color.B, value );
				}
			}
		}

		public double Hue
		{
			get
			{
				return Round( color.Hue );
			}
			set
			{
				if ( Round( color.Hue ) != value )
				{
					Color = Color.FromHsla( value, color.Saturation, color.Luminosity, color.A );
				}
			}
		}

		public double Saturation
		{
			get
			{
				return Round( color.Saturation );
			}
			set
			{
				if ( Round( color.Saturation ) != value )
				{
					Color = Color.FromHsla( color.Hue, value, color.Luminosity, color.A );
				}
			}
		}

		public double Luminosity
		{
			get
			{
				return Round( color.Luminosity );
			}
			set
			{
				if ( Round( color.Luminosity ) != value )
				{
					Color = Color.FromHsla( color.Hue, color.Saturation, value, color.A );
				}
			}
		}

		public Color Color
		{
			get
			{
				return color;
			}
			set
			{
				Color oldColor = value;

				if ( color != value )
				{
					color = value;
					OnPropertyChanged();
				}

				if ( color.R != oldColor.R )
					OnPropertyChanged( "Red" );

				if ( color.R != oldColor.G )
					OnPropertyChanged( "Green" );

				if ( color.R != oldColor.B )
					OnPropertyChanged( "Blue" );

				if ( color.R != oldColor.A )
					OnPropertyChanged( "Alpha" );

				if ( color.R != oldColor.Hue )
					OnPropertyChanged( "Hue" );

				if ( color.R != oldColor.Saturation )
					OnPropertyChanged( "Saturation" );

				if ( color.R != oldColor.Luminosity )
					OnPropertyChanged( "Luminosity" );


			}
		}

		protected void OnPropertyChanged( [CallerMemberName] string propertyName = null )
		{
			PropertyChangedEventHandler handler = PropertyChanged;

			if ( handler != null )
			{
				handler( this, new PropertyChangedEventArgs( propertyName ) );
			}
		}

		double Round( double value )
		{
			return Device.OnPlatform( value, Math.Round( value, 3 ), value );
		}
	}
}
