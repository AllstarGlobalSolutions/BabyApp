namespace BabyApp
{
	using System;
	using System.Net.Http;
	using System.Net.Http.Headers;
	using System.Text;
	using Newtonsoft.Json;
	using BabyApp.Helpers;

	public class ActivityModel
	{
		public Guid NeedId { get; set; }
		public Guid UserId { get; set; }
		public DateTime StartDttmUTC { get; set; }
		public DateTime EndDttmUTC { get; set; }
		public string Type { get; set; }
		public string Description { get; set; }

		public void Save()
		{
			using ( var client = new HttpClient() )
			{
				try
				{
					client.DefaultRequestHeaders.Clear();
					client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );


					HttpContent content = new StringContent( JsonConvert.SerializeObject( this ), Encoding.UTF8, "application/json" );
					Uri uri = new Uri( Settings.ACTIVITY_URL, UriKind.Absolute );

					//TODO: for now we're not going to track errors...in the future it would be nice to save it locally and try again later
					client.PostAsync( uri, content );
				}
				catch ( Exception e )
				{
					var m = e.Message;
				}
			}
		}
	}
}

