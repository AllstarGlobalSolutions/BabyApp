using System;
using System.ComponentModel;
using Xamarin.Forms;
using BabyApp.ViewModels;
using System.Xml.Serialization;
using System.IO;
using BabyApp.Helpers;

namespace BabyApp
{
	public partial class NeedPage : ContentPage
	{
		private NeedViewModel NeedViewModel { get; set; }
		private AdViewModel AdViewModel { get; set; }

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
			needImage.Source = NeedViewModel.ImageUrl;
			//ImageSource.FromUri( new Uri( "http://www.bet.com/news/national/2016/06/09/tragic--mother-kills-her-small-children-while-on-family-vacation/_jcr_content/image.heroimage.dimg/__1465504128251/060916-national-tragic-mother-kills-her-small-children-while-on-family-vacation.jpg" ) );
		}

		protected void GetNextAd()
		{
			adImage.Source = AdViewModel.AdImageUrl;
			//ImageSource.FromUri( new Uri( "http://marketingforhippies.com/wp-content/uploads/2015/03/small-is-beautiful-banner.png" ) );
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

