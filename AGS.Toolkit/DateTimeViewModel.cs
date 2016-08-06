using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;

namespace AGS.Toolkit
{
	public class DateTimeViewModel : INotifyPropertyChanged
	{
		DateTime dateTime = DateTime.Now;

		public event PropertyChangedEventHandler PropertyChanged;

		public DateTimeViewModel()
		{
			Device.StartTimer( TimeSpan.FromMilliseconds( 15 ), OnTimerTick );
		}

		bool OnTimerTick()
		{
			DateTime = DateTime.Now;
			return true;
		}
		
		public DateTime DateTime
		{
			get { return dateTime; }
			private set
			{
				if ( dateTime != value )
				{
					dateTime = value;

					// fire event
					PropertyChangedEventHandler handler = PropertyChanged;

					if ( handler != null )
					{
						handler( this, new PropertyChangedEventArgs( "DateTime" ) );
					}
				}
			}
		}
	}
}
