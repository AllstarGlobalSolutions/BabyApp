using System;
using System.Net;
using System.ComponentModel;
using Xamarin.Forms;
using BabyApp.ViewModels;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using BabyApp.Helpers;

namespace BabyApp
{
	public partial class NeedPage : ContentPage
	{
		[DataContract]
		class Need
		{
			public Guid NeedId = Guid.Empty;
			public string NeedType = null;
			public decimal AmountNeeded;
			public string OrganiztionName = null;
			public string OrganizationInfo = null;
			public string ImageUrl = null;
			public string Caption = null;
			public string Story = null;
		}

		[DataContract]
		class Ad
		{
			public string ImageUrl = null;
			public string ClickUrl = null;
		}

		private const string BASE_URL = "192.168.1.6:61360/api";
		private string NEXT_NEED_URL = BASE_URL + "/Needs/Next/";
		private string NEXT_AD_URL = BASE_URL + "/Advertisements/Next/";

		private NeedViewModel NeedViewModel { get; set; }
		private AdViewModel AdViewModel { get; set; }
		private WebRequest needRequest;
		private WebRequest adRequest;
		private Need need;
		private Ad ad;

		public NeedPage()
		{
			InitializeComponent();
			NeedViewModel = new NeedViewModel();
			AdViewModel = new AdViewModel();
			BindingContext = NeedViewModel;
			GetNextNeed();
			GetNextAd();
		}

		protected void GetNextNeed()
		{
			Uri uri = new Uri( NEXT_NEED_URL + Settings.Email );
			needRequest = WebRequest.Create( uri );
			needRequest.BeginGetResponse( NeedResponseCallback, null );
		}

		void NeedResponseCallback( IAsyncResult result )
		{
			Device.BeginInvokeOnMainThread( () =>
			{
				Stream stream = needRequest.EndGetResponse( result ).GetResponseStream();

				// Deserialize the JSON into imageList;
				var jsonSerializer = new DataContractJsonSerializer( typeof( Need ) );
				need = ( Need )jsonSerializer.ReadObject( stream );
				needImage.Source = ImageSource.FromUri( new Uri( need.ImageUrl ) );
			} );
		}

		protected void GetNextAd()
		{
			Uri uri = new Uri( NEXT_AD_URL + Settings.Email );
			adRequest = WebRequest.Create( uri );
			adRequest.BeginGetResponse( AdResponseCallback, null );
		}

		void AdResponseCallback( IAsyncResult result )
		{
			Device.BeginInvokeOnMainThread( () =>
			{
				Stream stream = needRequest.EndGetResponse( result ).GetResponseStream();

				// Deserialize the JSON into imageList;
				var jsonSerializer = new DataContractJsonSerializer( typeof( Ad ) );
				ad = ( Ad )jsonSerializer.ReadObject( stream );
				adImage.Source = ImageSource.FromUri( new Uri( ad.ImageUrl ) );
			} );
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
				Navigation.PushAsync( new NeedDetailPage() );
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
					serializer.Serialize( writer, this.NeedViewModel );
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
				NeedViewModel = ( NeedViewModel )serializer.Deserialize( stringReader );
			}

			// Load Need into page
		}

		protected void RemoveSavedNeed( int index )
		{
			Settings.RemoveSavedNeed( index );
		}
	}
}

