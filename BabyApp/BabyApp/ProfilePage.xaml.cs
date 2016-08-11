using System;
using System.Text;
using Xamarin.Forms;
using BabyApp.Helpers;
using BabyApp.ViewModels;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

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

			if ( !String.IsNullOrEmpty( Settings.Email ) )
			{
				RegisterButton.IsVisible = false;
			}
		}

		// return true handles disables the back button forcing the user to click the regiser button
		protected override bool OnBackButtonPressed()
		{
			return true;
		}

		public void OnRegisterButtonClicked( object sender, EventArgs e )
		{
			RegisterUser();
		}

		public async void RegisterUser()
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
					HttpResponseMessage response = await client.PostAsync( Settings.REGISTER_URL, content );

					if ( response.IsSuccessStatusCode )
					{
						SaveSettings();
						Navigation.PopModalAsync();
					}
					else
					{
						ErrorLabel.Text = response.ReasonPhrase;
						ErrorLabel.IsVisible = true;
					}
				}
				catch ( Exception e )
				{
					ErrorLabel.Text = e.Message;
					ErrorLabel.IsVisible = true;
				}
			}
		}

		void SaveSettings()
		{
			Settings.Email = profileViewModel.Email;
			Settings.Surname = profileViewModel.Surname;
			Settings.GivenName = profileViewModel.GivenName;
			Settings.AgeRange = profileViewModel.AgeRange;
			Settings.Gender = profileViewModel.Gender;
			Settings.Occupation = profileViewModel.Occupation;
		}
	}
}

