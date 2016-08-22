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
			NavigationPage.SetHasNavigationBar( this, false );

			if ( String.IsNullOrEmpty( Settings.UserId ) )
			{
				Navigation.PushModalAsync( new ProfilePage() );
			}
			else
			{
				Login();
			}
		}

		public async void Login()
		{
			App app = ( ( App )Application.Current );

			if ( !( await app.LoginAsync() ) )
			{
				ErrorLabel.Text = app.LoginError;
				ErrorLabel.IsVisible = true;
			}
		}

		void OnImageTapped( object sender, EventArgs e )
		{
			Navigation.PushAsync( new NeedTabbedPage() );
	
			// no need to return to the Welcome Page without restarting the app.
			Navigation.RemovePage( this );
		}
	}
}

