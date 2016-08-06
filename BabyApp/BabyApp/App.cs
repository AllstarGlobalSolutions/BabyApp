using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using AGS.Toolkit;

namespace BabyApp
{
	public class App : Application
	{
		public Button pushButton;

		public App()
		{
			AGS.Toolkit.Toolkit.Init();

			// if the user is already registered
			if ( Application.Current.Properties.ContainsKey( "Email" ) )
			{
				MainPage = new NavigationPage( new WelcomePage() );
			}
			else
			{
				MainPage = new NavigationPage( new ProfilePage() );
			}
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
