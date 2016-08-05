using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace BabyApp
{
	public partial class NeedViewPage : ContentPage
	{
		public NeedViewPage()
		{
			InitializeComponent();
		}

		public void OnImagePropertyChanged( object sender, PropertyChangedEventArgs args )
		{
			if ( args.PropertyName == "IsLoading" )
			{
				activityIndicator.IsRunning = ( ( Image )sender ).IsLoading;
			}
		}

		public void OnToolbarItemClicked( object sender, EventArgs args )
		{
			ToolbarItem toolbarItem = ( ToolbarItem )sender;

			switch ( toolbarItem.Text )
			{
				case "Details":
					break;

				case "Org Info":
					break;

				case "Donate":
					break;

				case "Save":
					break;
			}
		}
	}
}

