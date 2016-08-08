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
//			adImage.Source = GetNextAdImageSource();
//			needImage.Source = GetNextNeedImageSource();
		}

		protected ImageSource GetNextAdImageSource()
		{
			return ImageSource.FromUri( new Uri( "" ) );
		}

		protected ImageSource GetNextNeedImageSource()
		{
			return ImageSource.FromUri( new Uri( "" ) );
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
			throw new NotImplementedException();
		}
	}
}

