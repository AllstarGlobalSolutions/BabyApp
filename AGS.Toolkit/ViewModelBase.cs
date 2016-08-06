using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace AGS.Toolkit
{
	public class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		bool SetProperty<T>( ref T storage, T value, [CallerMemberName] string propertyName = null )
		{
			if ( Object.Equals( storage, value ) )
				return false;

			storage = value;
			OnPropertyChanged( propertyName );
			return true;
		}

		protected void OnPropertyChanged( [CallerMemberName] string propertyName = null )
		{
			PropertyChangedEventHandler handler = PropertyChanged;

			if ( handler != null )
			{
				PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
			}
		}
	}
}
