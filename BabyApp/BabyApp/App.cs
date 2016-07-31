using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BabyApp
{
	public class App : Application
	{
		public Button pushButton;

		public App()
		{
			pushButton = new Button
			{
				HeightRequest = 160,
				WidthRequest = 160,
				Image = ( FileImageSource )FileImageSource.FromFile( "button-up.png" ),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};

			pushButton.Clicked += PushButton_Clicked;

			// The root page of your application
			MainPage = new ContentPage
			{
				BackgroundColor = Color.Teal,
				Content = new StackLayout
				{
					VerticalOptions = LayoutOptions.Center,
					HorizontalOptions = LayoutOptions.Center,
					Padding = 20,
					Children = {
						pushButton
					}
				}
			};

		}

		private void PushButton_Clicked( object sender, EventArgs e )
		{
			Button button = ( Button )sender;
			button.Image = ( FileImageSource )FileImageSource.FromFile( "button-pressed.png" );
			// then go to new page
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
