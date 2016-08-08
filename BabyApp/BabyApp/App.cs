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
		public ProfileViewModel ProfileViewModel { get; private set; }

		public App()
		{
			Toolkit.Init();
			ProfileViewModel = new ProfileViewModel();

			MainPage = new NavigationPage( new WelcomePage() );
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
