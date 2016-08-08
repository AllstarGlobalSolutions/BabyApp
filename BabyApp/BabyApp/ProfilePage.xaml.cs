using System;
using System.Net.Http;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace BabyApp
{
	public partial class ProfilePage : ContentPage
	{
/*
		[DataContract]
		class ImageList
		{
			[DataMember( Name = "photos" )]
			public List<string> Photos = null;
		}*/
		public ProfilePage()
		{
			InitializeComponent();

			ProfileViewModel profileViewModel = ( ( App )Application.Current ).ProfileViewModel;
			BindingContext = profileViewModel;

			if ( Application.Current.Properties.ContainsKey( "Email" ) )
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
			RegisterUserAsync();
		}

		public async void RegisterUserAsync()
		{
/* TODO: TEST
			HttpClient client = new HttpClient();
			// The default size of this property is the maximum size of an integer. Therefore, the property is set to a smaller value, as a safeguard,
			//    in order to limit the amount of data that the application will accept as a response from the web service.
			client.MaxResponseContentBufferSize = 256000;

			Uri uri = new Uri( "http://localhost:61360/Accounts/Register" );
			string json = JsonConvert.SerializeObject( profileViewModel );
			StringContent content = new StringContent( json, Encoding.UTF8, "application/json" );

			HttpResponseMessage response = await client.PostAsync( uri, content );
*/
//			if ( response.IsSuccessStatusCode )
//			{
				// Save Settings locally
//				SaveSettings();

				// pop this page and go to welcome page
				await Navigation.PopModalAsync();
//			}
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

