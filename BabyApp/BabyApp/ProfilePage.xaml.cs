using System;
using System.Text;
using Xamarin.Forms;
using BabyApp.Helpers;
using BabyApp.ViewModels;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using AGS.Toolkit;

namespace BabyApp
{
	public partial class ProfilePage : ContentPage
	{
		ProfileViewModel profileViewModel = ( ( App )Application.Current ).ProfileViewModel;

		[JsonObject( MemberSerialization.OptIn )]
		class RegisterModel
		{
			[JsonProperty]
			public string Email { get; set; }
			[JsonProperty]
			public string Surname { get; set; }
			[JsonProperty]
			public int Type { get; set; }
			[JsonProperty]
			public string Password { get; set; }
			[JsonProperty]
			public string ConfirmPassword { get; set; }
		}

		public ProfilePage()
		{
			InitializeComponent();

			BindingContext = profileViewModel;

			if ( !String.IsNullOrEmpty( Settings.UserId ) )
			{
				RegisterButton.IsVisible = false;
			}
		}

		// return true handles disables the back button forcing the user to click the regiser button
		protected override bool OnBackButtonPressed()
		{
			return true;
		}

		public async void OnRegisterButtonClicked( object sender, EventArgs e )
		{
			if ( await RegisterUserAsync() )
			{
				SendDeviceInfo();
				await Navigation.PopModalAsync();
			}
		}

		public async Task<bool> RegisterUserAsync()
		{
			ErrorLabel.IsVisible = false;

			using ( var client = new HttpClient() )
			{
				try
				{
					client.DefaultRequestHeaders.Clear();
					client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );

					RegisterModel rm = new RegisterModel
					{
						Email = profileViewModel.Email,
						Surname = profileViewModel.Surname ?? "Anonymous",
						Type = 2,
						Password = "Password@123",
						ConfirmPassword = "Password@123"
					};

					HttpContent content = new StringContent( JsonConvert.SerializeObject( rm ), Encoding.UTF8, "application/json" );
					Uri uri = new Uri( String.Format( Settings.REGISTER_URL, Settings.Email ), UriKind.Absolute );
					HttpResponseMessage response = await client.PostAsync( uri, content );

					if ( response.IsSuccessStatusCode )
					{
						string json = await response.Content.ReadAsStringAsync();
						profileViewModel.UserId = JsonConvert.DeserializeObject<string>( json );
						SaveSettings();
						App app = ( ( App )Application.Current );

						if ( !( await app.LoginAsync() ) )
						{
							ErrorLabel.Text = app.LoginError;
							ErrorLabel.IsVisible = true;
							return false;
						}
						else
						{
							return true;
						}
					}
					else
					{
						StreamContent sc = response.Content as StreamContent;
						string json = await sc.ReadAsStringAsync();
						if ( json.Contains( "already taken" ) )
						{
							ErrorLabel.Text = "Email already in use";
							ErrorLabel.IsVisible = true;
						}
						else
						{
							ErrorLabel.Text = "Unknown Error.  Try again Later.";
							ErrorLabel.IsVisible = true;
						}

						return false;
					}
				}
				catch ( Exception e )
				{
					ErrorLabel.Text = e.Message;
					ErrorLabel.IsVisible = true;
					return false;
				}
			}
		}

		async void SendDeviceInfo()
		{
			IPlatformInfo platformInfo = DependencyService.Get<IPlatformInfo>();
			string userId = Settings.UserId;
			PlatformModel pm = new PlatformModel
			{
				UserId = Guid.Parse( Settings.UserId ),
				Model = platformInfo.GetModel(),
				Manufacturer = platformInfo.GetManufacturer(),
				Version = platformInfo.GetVersion(),
				OS = platformInfo.GetOS()
			};

			if ( await pm.Save() )
			{
				Settings.DeviceSaved = true;
			}
		}

		void SaveSettings()
		{
			Settings.UserId = profileViewModel.UserId;
			Settings.Email = profileViewModel.Email;
			Settings.Surname = profileViewModel.Surname;
			Settings.GivenName = profileViewModel.GivenName;
			Settings.AgeRange = profileViewModel.AgeRange;
			Settings.Gender = profileViewModel.Gender;
			Settings.Occupation = profileViewModel.Occupation;
			Application.Current.SavePropertiesAsync();
		}
	}
}

