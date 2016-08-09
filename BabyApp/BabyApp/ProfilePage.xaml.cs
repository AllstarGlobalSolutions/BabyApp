using System;
using Xamarin.Forms;
using BabyApp.Helpers;
using BabyApp.ViewModels;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.IO;

namespace BabyApp
{
	public partial class ProfilePage : ContentPage
	{
		ProfileViewModel profileViewModel = ( ( App )Application.Current ).ProfileViewModel;

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
			using ( var client = new HttpClient() )
			{
				client.BaseAddress = new Uri( "http:192.168.1.6:61360/api" );
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
				var serializer = new DataContractJsonSerializer( typeof( ProfileViewModel ) );
				var ms = new MemoryStream();
				serializer.WriteObject( ms, profileViewModel );
				HttpContent content = new StreamContent( ms );
				HttpResponseMessage response = await client.PostAsync( "/Donors/Register", content );

				if ( response.IsSuccessStatusCode )
				{
					// Save Settings locally
					SaveSettings();

					// pop this page and go to welcome page
					await Navigation.PopModalAsync();
				}
			}
		}

		public void SaveSettings()
		{
			ProfileViewModel profileViewModel = ( ProfileViewModel )BindingContext;

			Settings.Email = profileViewModel.Email;
			Settings.Surname = profileViewModel.Surname;
			Settings.GivenName = profileViewModel.GivenName;
			Settings.AgeRange = profileViewModel.AgeRange;
			Settings.Gender = profileViewModel.Gender;
			Settings.Occupation = profileViewModel.Occupation;
		}


		//		public async Task<Place[]> GetPlacesAsync()
		//		{
		//			var client = new System.Net.Http.HttpClient();
		//			client.BaseAddress = new Uri( "http://api.geonames.org/" );
		//			StringContent str = new StringContent( "postalcode=752020&country=IN&username=nirmalh", Encoding.UTF8, "application/x-www-form-urlencoded" );
		//			var response = await client.PostAsync( new Uri( "http://api.geonames.org/postalCodeLookupJSON" ), str );
		//			var placesJson = response.Content.ReadAsStringAsync().Result;
		//			Placeobject placeobject = new Placeobject();
		//			if ( placesJson != "" )
		//			{
		//				placeobject = JsonConvert.DeserializeObject<Placeobject>( placesJson );
		//			}
		//			return placeobject.places;
		//		}

		//		protected async Task<string> Register()
		//		{





		//			var client = new System.Net.Http.HttpClient();
		//			client.BaseAddress = new Uri( "http://api.geonames.org/" );
		//			var response = await client.GetAsync( "postalCodeLookupJSON?postalcode=751010&country=IN&username=nirmalh" );
		//			var placesJson = response.Content.ReadAsStringAsync().Result;
		//			Placeobject placeobject = new Placeobject();
		//			if ( placesJson != "" )
		//			{
		//				placeobject = JsonConvert.DeserializeObject<Placeobject>( placesJson );
		//			}
		//			return placeobject.places;
		//		}
	}
}

