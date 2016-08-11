using System;
using BabyApp.Helpers;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
			else
			{
				App app = ( ( App )Application.Current );
				app.Login();

				if ( app.LoginError != null )
				{
					ErrorLabel.Text = app.LoginError;
					ErrorLabel.IsVisible = true;
				}
			}
		}

		void OnImageTapped( object sender, EventArgs e )
		{
			Navigation.PushAsync( new NeedPage() );
		}
	}
}

