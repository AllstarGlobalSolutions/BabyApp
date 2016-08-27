using System;
using System.Collections.Generic;
using BabyApp.Helpers;
using Xamarin.Forms;

namespace BabyApp
{
	public partial class NetworkSettings : ContentPage
	{
		public NetworkSettings()
		{
			InitializeComponent();

			baseUrlEntry.Text = Settings.BaseUrl;
			loginUrlEntry.Text = Settings.LoginUrl;
			registerUrlEntry.Text = Settings.RegisterUrl;
			nextNeedUrlEntry.Text = Settings.NextNeedUrl;
			nextAdUrlEntry.Text = Settings.NextAdUrl;
			imageUrlEntry.Text = Settings.ImageUrl;
			activityUrlEntry.Text = Settings.ActivityUrl;
			deviceUrlEntry.Text = Settings.DeviceUrl;
			needTypeUrlEntry.Text = Settings.NeedTypeUrl;
			regionUrlEntry.Text = Settings.RegionUrl;
			countryUrlEntry.Text = Settings.CountryUrl;
		}

		public void OnSaveClicked( object sender, EventArgs args )
		{
			Settings.BaseUrl = baseUrlEntry.Text;
			Settings.LoginUrl = loginUrlEntry.Text;
			Settings.RegisterUrl = registerUrlEntry.Text;
			Settings.NextNeedUrl = nextNeedUrlEntry.Text;
			Settings.NextAdUrl = nextAdUrlEntry.Text;
			Settings.ImageUrl = imageUrlEntry.Text;
			Settings.ActivityUrl = activityUrlEntry.Text;
			Settings.DeviceUrl = deviceUrlEntry.Text;
			Settings.NeedTypeUrl = needTypeUrlEntry.Text;
			Settings.RegionUrl = regionUrlEntry.Text;
			Settings.CountryUrl = countryUrlEntry.Text;
			Application.Current.SavePropertiesAsync();
		}
	}
}

