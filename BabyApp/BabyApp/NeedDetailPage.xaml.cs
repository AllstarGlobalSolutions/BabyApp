using System;
using System.Collections.Generic;
using BabyApp.Helpers;
using BabyApp.ViewModels;
using Xamarin.Forms;

namespace BabyApp
{
	public partial class NeedDetailPage : ContentPage
	{
		public NeedDetailPage( string story, string imageUrl )
		{
			InitializeComponent();

			Uri imageUri = new Uri( imageUrl, UriKind.Absolute );
			image.Source = ImageSource.FromUri( imageUri );
			storyLabel.Text = story;
		}
	}
}

