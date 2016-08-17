using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using BabyApp.Helpers;
using Xamarin.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BabyApp
{
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage()
		{
			InitializeComponent();

			LoadNeedTypes();
			LoadRegions();
			LoadCountries();
		}

		class NeedType
		{
			public Guid NeedTypeId { get; set; }
			public string Description { get; set; }
			public override string ToString()
			{
				return Description;
			}
		}

		async void LoadNeedTypes()
		{
			using ( var client = new HttpClient() )
			{
				try
				{
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", Settings.AccessToken );

					Uri uri = new Uri( String.Format( Settings.NEED_TYPES_URL, Settings.UserId ), UriKind.Absolute );
					HttpResponseMessage response = await client.GetAsync( uri );

					if ( response.IsSuccessStatusCode )
					{
						List<NeedType> needTypes = JsonConvert.DeserializeObject<List<NeedType>>( await response.Content.ReadAsStringAsync() );
						NeedTypes.ItemsSource = needTypes;
					}
					else
					{
						NeedTypes.ItemsSource = new List<NeedType>();
					}
				}
				catch ( Exception e )
				{
					var m = e.Message;
					NeedTypes.ItemsSource = new List<NeedType>();
				}
			}
		}

		class Region
		{
			public Guid RegionId { get; set; }
			public string Name { get; set; }

			public override string ToString()
			{
				return Name;
			}
		}

		async void LoadRegions()
		{
			using ( var client = new HttpClient() )
			{
				try
				{
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", Settings.AccessToken );

					Uri uri = new Uri( String.Format( Settings.REGIONS_URL, Settings.UserId ), UriKind.Absolute );
					HttpResponseMessage response = await client.GetAsync( uri );

					if ( response.IsSuccessStatusCode )
					{
						List<Region> regions = JsonConvert.DeserializeObject<List<Region>>( await response.Content.ReadAsStringAsync() );
						Regions.ItemsSource = regions;
					}
					else
					{
						Regions.ItemsSource = new List<Region>();
					}
				}
				catch ( Exception e )
				{
					var m = e.Message;
					Regions.ItemsSource = new List<Region>();
				}
			}
		}

		class Country
		{
			public Guid CountryId { get; set; }
			public string Code { get; set; }
			public string Name { get; set; }

			public override string ToString()
			{
				return Name;
			}
		}
		async void LoadCountries()
		{
			using ( var client = new HttpClient() )
			{
				try
				{
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", Settings.AccessToken );

					Uri uri = new Uri( String.Format( Settings.COUNTRIES_URL, Settings.UserId ), UriKind.Absolute );
					HttpResponseMessage response = await client.GetAsync( uri );

					if ( response.IsSuccessStatusCode )
					{
						List<Country> countries = JsonConvert.DeserializeObject<List<Country>>( await response.Content.ReadAsStringAsync() );
						Countries.ItemsSource = countries;
					}
					else
					{
						Countries.ItemsSource = new List<Country>();
					}
				}
				catch ( Exception e )
				{
					var m = e.Message;
					Countries.ItemsSource = new List<Country>();
				}
			}
		}

		void OnNeedTypeClicked( object sender, EventArgs args )
		{
			Regions.IsVisible = false;
			Countries.IsVisible = false;
			NeedTypes.IsVisible = true;
		}

		void OnRegionClicked( object sender, EventArgs args )
		{
			NeedTypes.IsVisible = false;
			Countries.IsVisible = false;
			Regions.IsVisible = true;
		}

		void OnCountryClicked( object sender, EventArgs args )
		{
			NeedTypes.IsVisible = false;
			Regions.IsVisible = false;
			Countries.IsVisible = true;
		}
	}
}

