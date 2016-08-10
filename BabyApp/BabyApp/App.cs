using System;
using System.IO;
using Xamarin.Forms;
using AGS.Toolkit;
using BabyApp.ViewModels;
using BabyApp.Helpers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BabyApp
{
	public class App : Application
	{
		public ProfileViewModel ProfileViewModel { get; private set; }
		public string AccessToken { get; set; }

		[DataContract]
		class LoginModel
		{
			public string grant_type { get; set; }
			public string username { get; set; }
			public string password { get; set; }
		}

		[DataContract]
		class LoginResponse
		{
			public string access_token { get; set; }
			public string token_type { get; set; }
			public int expires_in { get; set; }
			public string userName { get; set; }
		}

		public App()
		{
			Toolkit.Init();
			ProfileViewModel = new ProfileViewModel();

			MainPage = new NavigationPage( new WelcomePage() );
		}

		public async void LoginAsync()
		{
			using ( var client = new HttpClient() )
			{
				client.BaseAddress = new Uri( Settings.BASE_URL );
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/x-www-form-urlecoded" ) );

				LoginModel lm = new LoginModel { username = Settings.Email, password = "Password@123" };
				var ms = new MemoryStream();
				var serializer = new DataContractJsonSerializer( typeof( LoginModel ) );
				serializer.WriteObject( ms, lm );
				HttpContent content = new StreamContent( ms );
				HttpResponseMessage response = await client.PostAsync( "/token", content );

				if ( response.IsSuccessStatusCode )
				{
					var data = ( LoginResponse )serializer.ReadObject( await response.Content.ReadAsStreamAsync() );
					( ( App )Application.Current ).AccessToken = data.access_token;
					Settings.AccessToken = data.access_token;
				}
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
