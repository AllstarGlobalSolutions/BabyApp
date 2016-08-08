using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace BabyApp
{
	public partial class NeedViewPage : ContentPage
	{
		public NeedViewPage()
		{
			InitializeComponent();
			adImage.Source = GetNextAdImageSource();
			needImage.Source = GetNextNeedImageSource();
		}

		protected ImageSource GetNextAdImageSource()
		{
			return ImageSource.FromUri( new Uri( "http://marketingforhippies.com/wp-content/uploads/2015/03/small-is-beautiful-banner.png" ) );
		}

		protected ImageSource GetNextNeedImageSource()
		{
			return ImageSource.FromUri( new Uri( "http://www.bet.com/news/national/2016/06/09/tragic--mother-kills-her-small-children-while-on-family-vacation/_jcr_content/image.heroimage.dimg/__1465504128251/060916-national-tragic-mother-kills-her-small-children-while-on-family-vacation.jpg" ) );
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
				Navigation.PushAsync( new NeedDetailViewPage() );
				break;

			case "Org Info":
				Navigation.PushAsync( new OrganizationViewPage() );
				break;

			case "Donate":
				Navigation.PushAsync( new DonationViewPage() );
				break;

			case "Save":
				SaveNeed();
				break;

			case "Saved Needs":
				Navigation.PushAsync( new SavedNeedsViewPage() );
				break;
			}
		}

		protected void SaveNeed()
		{
			//throw new NotImplementedException();
		}
	}
}

