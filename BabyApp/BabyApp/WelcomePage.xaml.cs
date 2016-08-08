using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BabyApp
{
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage()
		{
			InitializeComponent();

			if ( String.IsNullOrEmpty( Settings.Email ) )
			{
				Navigation.PushModalAsync( new ProfilePage() );
			}
		}

		void OnImageTapped( object sender, EventArgs e )
		{
			Navigation.PushAsync( new NeedViewPage() );
		}
	}
}

