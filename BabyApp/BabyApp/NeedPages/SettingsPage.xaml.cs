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
						string json = await response.Content.ReadAsStringAsync();
						List<NeedType> needTypes = JsonConvert.DeserializeObject<List<NeedType>>( json );
						NeedTypeTable.Root.Add( new TableSection() );
						string savedNeedTypes = Settings.NeedTypes;

						foreach ( NeedType nt in needTypes )
						{
							SwitchCell cell = new SwitchCell();
							cell.Text = nt.Description;

							if ( String.IsNullOrEmpty( savedNeedTypes ) || savedNeedTypes.Contains( nt.Description ) )
							{
								cell.On = true;
							}
							else
							{
								cell.On = false;
							}
							NeedTypeTable.Root[ 0 ].Add( cell );
						}
//						NeedTypes.ItemsSource = needTypes;
					}
					else
					{
						NeedTypeTable.Root.Add( new TableSection() );
						NeedTypeTable.Root[ 0 ].Add( new SwitchCell { Text = "Hunger", On = true } );
//						NeedTypes.ItemsSource = new List<NeedType>();
					}
				}
				catch ( Exception e )
				{
					var m = e.Message;
					//					NeedTypes.ItemsSource = new List<NeedType>();
					NeedTypeTable.Root.Add( new TableSection() );
					NeedTypeTable.Root[ 0 ].Add( new SwitchCell { Text = "Hunger", On = true } );
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
						RegionTable.Root.Add( new TableSection() );
						string savedRegions = Settings.Regions;

						foreach ( Region region in regions )
						{
							SwitchCell cell = new SwitchCell();
							cell.Text = region.Name;

							if ( String.IsNullOrEmpty( savedRegions ) || savedRegions.Contains( region.Name ) )
							{
								cell.On = true;
							}
							else
							{
								cell.On = false;
							}
							RegionTable.Root[ 0 ].Add( cell );
						}
//						Regions.ItemsSource = regions;
					}
					else
					{
						//						Regions.ItemsSource = new List<Region>();
						RegionTable.Root.Add( new TableSection() );
						RegionTable.Root[ 0 ].Add( new SwitchCell { Text = "Asia", On = true } );
					}
				}
				catch ( Exception e )
				{
					var m = e.Message;
					//					Regions.ItemsSource = new List<Region>();
					RegionTable.Root.Add( new TableSection() );
					RegionTable.Root[ 0 ].Add( new SwitchCell { Text = "Asia", On = true } );
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
						CountryTable.Root.Add( new TableSection() );
						string savedCountries = Settings.Countries;

						foreach ( Country country in countries )
						{
							SwitchCell cell = new SwitchCell();
							cell.Text = country.Name;

							if ( String.IsNullOrEmpty( savedCountries ) || savedCountries.Contains( country.Name ) )
							{
								cell.On = true;
							}
							else
							{
								cell.On = false;
							}
							CountryTable.Root[ 0 ].Add( cell );
						}
//						Countries.ItemsSource = countries;
					}
					else
					{
						//						Countries.ItemsSource = new List<Country>();
						CountryTable.Root.Add( new TableSection() );
						CountryTable.Root[ 0 ].Add( new SwitchCell { Text = "China", On = true } );
					}
				}
				catch ( Exception e )
				{
					var m = e.Message;
					//					Countries.ItemsSource = new List<Country>();
					CountryTable.Root.Add( new TableSection() );
					CountryTable.Root[ 0 ].Add( new SwitchCell { Text = "China", On = true } );
				}
			}
		}

		void OnNeedTypeClicked( object sender, EventArgs args )
		{
			//			Regions.IsVisible = false;
			//			Countries.IsVisible = false;
			//			NeedTypes.IsVisible = true;
			RegionTable.IsVisible = false;
			CountryTable.IsVisible = false;
			NeedTypeTable.IsVisible = true;
		}

		void OnRegionClicked( object sender, EventArgs args )
		{
			//			NeedTypes.IsVisible = false;
			//			Countries.IsVisible = false;
			//			Regions.IsVisible = true;
			NeedTypeTable.IsVisible = false;
			CountryTable.IsVisible = false;
			RegionTable.IsVisible = true;
		}

		void OnCountryClicked( object sender, EventArgs args )
		{
			//			NeedTypes.IsVisible = false;
			//			Regions.IsVisible = false;
			//			Countries.IsVisible = true;
			NeedTypeTable.IsVisible = false;
			RegionTable.IsVisible = false;
			CountryTable.IsVisible = true;
		}

		void OnSave( object sender, EventArgs args )
		{
		}
	}
}

