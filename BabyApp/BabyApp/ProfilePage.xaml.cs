using System;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BabyApp
{
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage()
		{
			InitializeComponent();

			if ( Application.Current.Properties.ContainsKey( "Email" ) )
			{
				RegisterButton.IsVisible = false;
			}
		}

		public void OnRegisterButtonClicked( object sender, EventArgs e )
		{
/*			var client = new HttpClient();
			client.BaseAddress = new Uri( "PATH/TO/RESTful API" );
			var response = client.GetAsync( "sub url" );
			var content = response.
			request.ContentType = "application/json";
			request.Method = "POST";

			using ( HttpWebResponse response = await request.GetResponseAsync() )
			{
				if ( response.StatusCode == HttpStatusCode.OK )
				{

				}
				using ( StreamReader reader = new StreamReader( response.GetResponseStream() ) )
				{
					var content = reader.ReadToEnd();
					if ( string.IsNullOrWhiteSpace( content ) )
					{

					}
					else
					{

					}
				}
			}
			*/
			//			Application.Current.Properties[ "Email" ] = this.EmailEntry.Text;
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

