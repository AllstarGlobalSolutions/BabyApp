using System;
using System.Net;
using System.ComponentModel;
using Xamarin.Forms;
using BabyApp.ViewModels;
using System.Xml.Serialization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using BabyApp.Helpers;
using Newtonsoft.Json;

namespace BabyApp
{
	public partial class NeedPage : ContentPage
	{
		class NeedResponse
		{
			public Guid NeedId { get; set; }
			public string Caption { get; set; }
			public string Story { get; set; }
			public Guid? FileId1 { get; set; }
			public Guid? FileId2 { get; set; }
			public string OrgName { get; set; }
			public string NeedType { get; set; }
			public string Tags { get; set; }
			public decimal? AmountNeeded { get; set; }
		}

		class AdResponse
		{
			public string FileId { get; set; }
			public string ClickUrl { get; set; }
		}

		private NeedViewModel nvm { get; set; }
		private AdViewModel AdViewModel { get; set; }
		private NeedResponse need;
		private AdResponse ad;

		public NeedPage()
		{
			InitializeComponent();
			nvm = new NeedViewModel();
			AdViewModel = new AdViewModel();
			BindingContext = nvm;
			GetNextNeedAsync();
			//GetNextAdAsync();
		}

		protected async void GetNextNeedAsync()
		{
			using ( var client = new HttpClient() )
			{
				try
				{
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", Settings.AccessToken );

					Uri uri = new Uri( String.Format( Settings.NEXT_NEED_URL, Settings.UserId ), UriKind.Absolute );
					HttpResponseMessage response = await client.GetAsync( uri );

					if ( response.IsSuccessStatusCode )
					{
						need = JsonConvert.DeserializeObject<NeedResponse>( await response.Content.ReadAsStringAsync() );
						nvm.Caption = need.Caption;
						nvm.Story = need.Story;

						string file1Id = need.FileId1.HasValue ? need.FileId1.ToString() : "";
						nvm.Image1Url = String.Format( Settings.IMAGE_URL, file1Id );

						string file2Id = need.FileId2.HasValue ? need.FileId2.ToString() : file1Id;
						nvm.Image2Url = String.Format( Settings.IMAGE_URL, file2Id );

						Uri imageUri = new Uri( nvm.Image1Url, UriKind.Absolute );
						needImage.Source = ImageSource.FromUri( imageUri );
					}
					else
					{
						var m = await response.Content.ReadAsStringAsync();
						nvm.Caption = m;
					}
				}
				catch ( Exception e )
				{
					var m = e.Message;
					nvm.Caption = m;
				}
			}
		}

		protected async void GetNextAdAsync()
		{
			using ( var client = new HttpClient() )
			{
				try
				{
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );

					Uri uri = new Uri( String.Format( Settings.NEXT_AD_URL, Settings.Email ), UriKind.Absolute );
					HttpResponseMessage response = await client.GetAsync( uri );

					if ( response.IsSuccessStatusCode )
					{
						ad = JsonConvert.DeserializeObject<AdResponse>( await response.Content.ReadAsStringAsync() );
						adImage.Source = ImageSource.FromUri( new Uri( String.Format( Settings.IMAGE_URL, ad.FileId.ToString() ), UriKind.Absolute ) );
					}
					else
					{
						// TODO: need to report error
						var m = response.RequestMessage;
					}
				}
				catch ( Exception e )
				{
					var m = e.Message;
				}
			}
		}

		public void OnImagePropertyChanged( object sender, PropertyChangedEventArgs args )
		{
			if ( args.PropertyName == "IsLoading" )
			{
				activityIndicator.IsRunning = ( ( Image )sender ).IsLoading;
			}
		}

		public void OnToolbarItemClicked( object sender, EventArgs args )
		{
			ToolbarItem toolbarItem = ( ToolbarItem )sender;

			switch ( toolbarItem.Text )
			{
			case "Details":
				NeedDetailPage detailPage = new NeedDetailPage( nvm.Story, nvm.Image2Url );
				Navigation.PushAsync( detailPage );
				break;

			case "Org Info":
				Navigation.PushAsync( new OrganizationPage() );
				break;

			case "Share":
				throw new NotImplementedException();

			case "Donate":
				Navigation.PushAsync( new DonationPage() );
				break;

			case "Save":
				SaveNeed();
				break;

			case "Saved Needs":
				Navigation.PushAsync( new SavedNeedsPage() );
				break;
			}
		}

		protected void SaveNeed()
		{
			if ( Settings.SavedCount < 10 )
			{
				XmlSerializer serializer = new XmlSerializer( typeof( NeedViewModel ) );

				using ( StringWriter writer = new StringWriter() )
				{
					serializer.Serialize( writer, this.nvm );
					Settings.SaveNextNeed( writer.GetStringBuilder().ToString() );
				}
				//TODO: show a "successfully saved" box
			}
			else
			{
				//TODO: Let the user know they already have the max saved
			}
		}

		protected void GetSavedNeed( int index )
		{
			XmlSerializer serializer = new XmlSerializer( typeof( NeedViewModel ) );

			using ( StringReader stringReader = new StringReader( Settings.GetSavedNeedAsString( index ) ) )
			{
				nvm = ( NeedViewModel )serializer.Deserialize( stringReader );
			}

			// Load Need into page
		}

		protected void RemoveSavedNeed( int index )
		{
			Settings.RemoveSavedNeed( index );
		}
	}
}

