using System;
using Xamarin.Forms;
using BabyApp.Helpers;
using BabyApp.ViewModels;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace BabyApp
{
	public partial class ProfilePage : ContentPage
	{
		ProfileViewModel profileViewModel = ( ( App )Application.Current ).ProfileViewModel;

		[DataContract]
		class RegisterModel
		{
			public string Email { get; set; }
			public string Password { get; set; }
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
			try
			{
				// Create a request using a URL that can receive a post. 
				WebRequest request = WebRequest.Create( "http://192.168.1.6:3000/api/Account/Register" );
				// Set the Method property of the request to POST.
				request.Method = "POST";
				// Create POST data and convert it to a byte array.
				string postData = "Username=" + profileViewModel.Email + "&Password=Password@123&ConfirmPassword=Password@123";
				byte[] byteArray = System.Text.Encoding.UTF8.GetBytes( postData );
				// Set the ContentType property of the WebRequest.
				request.ContentType = "application/x-www-form-urlencoded";
				// Get the request stream.
				Stream dataStream = await request.GetRequestStreamAsync();
				// Write the data to the request stream.
				dataStream.Write( byteArray, 0, byteArray.Length );
				// Get the response.
				WebResponse response = await request.GetResponseAsync();
				// Display the status.
				profileViewModel.GivenName = ( ( HttpWebResponse )response ).StatusDescription;
				// Get the stream containing content returned by the server.
				dataStream = response.GetResponseStream();
				// Open the stream using a StreamReader for easy access.
				StreamReader reader = new StreamReader( dataStream );
				// Read the content.
				string responseFromServer = reader.ReadToEnd();
			}
			catch ( WebException we )
			{
				profileViewModel.GivenName = we.Message;
			}
			/*
			var uri = new Uri( "http://192.168.1.6:3000/api/Account/Register" );
			RegisterModel rm = new RegisterModel
			{
				Email = profileViewModel.Email,
				Password = "Password@123",
				ConfirmPassword = "Password@123"
			};

			request = WebRequest.Create( uri );
			request.
			var serializer = new DataContractSerializer( typeof( RegisterModel ) );
			var stream = new MemoryStream();
			serializer.WriteObject( stream, rm );
			var content = new StreamContent( stream );

			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.PostAsync( uri, content );
			if ( response.IsSuccessStatusCode )
			{
				profileViewModel.GivenName = "success";
			}
			else
			{
				profileViewModel.GivenName = "failure";
			}
			*/
			/*			var content = new StringContent( json, System.Text.Encoding.UTF8, "application/json" );

						HttpResponseMessage response = null;
						HttpClient client = new HttpClient();
						response = await client.PostAsync( uri, content );

						if ( response.IsSuccessStatusCode )
						{
							profileViewModel.GivenName = "Success";
						}
						*/

			//			using ( var client = new HttpClient() )
			//			{
			/*
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
			var serializer = new DataContractJsonSerializer( typeof( RegisterModel ) );
			RegisterModel rm = new RegisterModel
			{
				Email = profileViewModel.Email,
				Password = "Password@123",
				ConfirmPassword = "Password@123"
			};
			var ms = new MemoryStream();
			serializer.WriteObject( ms, rm );
			HttpContent content = new StreamContent( ms );
			Uri uri = new Uri( "http://192.168.1.6:3000/api/Account/Register", UriKind.Absolute );
			HttpResponseMessage response = await client.PostAsync( uri, content );

			if ( response.IsSuccessStatusCode )
			{
				// Save Settings locally
				SaveSettings();
				( ( App )Application.Current ).LoginAsync();

				// pop this page and go to welcome page
				await Navigation.PopModalAsync();
			}
			*/
			//			}
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

