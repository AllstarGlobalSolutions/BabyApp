using System;
using Xamarin.Forms;
using AGS.Toolkit;
using BabyApp.ViewModels;
using BabyApp.Helpers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BabyApp
{
	public class App : Application
	{
		public ProfileViewModel ProfileViewModel { get; private set; }
		public string AccessToken { get; set; }

		[JsonObject( MemberSerialization.OptIn )]
		class LoginModel
		{
			[JsonProperty]
			public string grant_type { get; set; }
			[JsonProperty]
			public string username { get; set; }
			[JsonProperty]
			public string password { get; set; }
		}

		[JsonObject( MemberSerialization.OptIn )]
		class LoginResponse
		{
			[JsonProperty]
			public string access_token { get; set; }
			[JsonProperty]
			public string token_type { get; set; }
			[JsonProperty]
			public int expires_in { get; set; }
			[JsonProperty]
			public string userName { get; set; }
			[JsonProperty( ".issued" )]
			public string IssuedDateTime { get; set; }
			[JsonProperty( ".expires" )]
			public string ExpiresDateTime { get; set; }
		}

		public App()
		{
			Toolkit.Init();
			ProfileViewModel = new ProfileViewModel();

			NavigationPage navPage = new NavigationPage( new WelcomePage() );
			navPage.BackgroundColor = Color.FromRgb( 0x34, 0x98, 0xDB );
			navPage.BarBackgroundColor = Color.FromRgb( 0x34, 0x98, 0xDB );
			navPage.BarTextColor = Color.Black;

			MainPage = navPage;
		}

		public string LoginError = null;

		public async Task<bool> LoginAsync()
		{
			using ( var client = new HttpClient() )
			{
				try
				{
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );

					string loginString = "grant_type=password&username=" + Settings.Email + "&password=Password@123";
					HttpContent content = new StringContent( loginString, Encoding.UTF8, "application/x-www-form-urlencoded" );
					Uri uri = new Uri( Settings.LOGIN_URL, UriKind.Absolute );
					HttpResponseMessage response = await client.PostAsync( uri, content );

					if ( response.IsSuccessStatusCode )
					{
						var data = JsonConvert.DeserializeObject<LoginResponse>( await response.Content.ReadAsStringAsync() );
						( ( App )Application.Current ).AccessToken = data.access_token;
						Settings.AccessToken = data.access_token;
						LoginError = null;
						return true;
					}
					else
					{
						StreamContent sc = response.Content as StreamContent;
						string json = await sc.ReadAsStringAsync();
						LoginError = json;
						return false;
					}
				}
				catch ( Exception e )
				{
					LoginError = e.Message;
					return false;
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
