namespace BabyApp
{
	using System;
	using System.Net.Http;
	using System.Net.Http.Headers;
	using System.Text;
	using Newtonsoft.Json;
	using BabyApp.Helpers;
	using System.Threading.Tasks;

	public class PlatformModel
	{
		public Guid UserId { get; set; }
		public string Manufacturer { get; set; }
		public string Model { get; set; }
		public string Version { get; set; }
		public string OS { get; set; }

		public async Task<bool> Save()
		{
			using ( var client = new HttpClient() )
			{
				try
				{
					client.DefaultRequestHeaders.Clear();
					client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );


					HttpContent content = new StringContent( JsonConvert.SerializeObject( this ), Encoding.UTF8, "application/json" );
					Uri uri = new Uri( Settings.BaseUrl + Settings.DeviceUrl, UriKind.Absolute );

					//TODO: for now we're not going to track errors...in the future it would be nice to save it locally and try again later
					HttpResponseMessage response = await client.PostAsync( uri, content );

					if ( response.IsSuccessStatusCode )
					{
						return true;
					}
				}
				catch ( Exception e )
				{
					var m = e.Message;
				}

				return false;
			}
		}
	}
}

