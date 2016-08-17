using System;
using System.Collections.Generic;
using BabyApp.Helpers;
using BabyApp.ViewModels;
using Xamarin.Forms;

namespace BabyApp
{
	public partial class NeedDetailPage : ContentPage
	{
		private DateTime viewDetailStart { get; set; }
		private Guid needId { get; set; }
		private string caption { get; set; }

		public NeedDetailPage( Guid needId, string caption, string story, string imageUrl )
		{
			InitializeComponent();

			Uri imageUri = new Uri( imageUrl, UriKind.Absolute );
			image.Source = ImageSource.FromUri( imageUri );
			storyLabel.Text = story;
			viewDetailStart = DateTime.UtcNow;
			this.needId = needId;
			this.caption = caption;
		}

		protected override bool OnBackButtonPressed()
		{
			return base.OnBackButtonPressed();
		}

		protected void SaveActivity()
		{
			ActivityModel am = new ActivityModel
			{
				NeedId = this.needId,
				UserId = Guid.Parse( Settings.UserId ),
				StartDttmUTC = this.viewDetailStart,
				EndDttmUTC = DateTime.UtcNow,
				Type = "ViewNeedDetail",
				Description = "The Need with Caption " + this.caption + " was viewed in the detail mode."
			};

			am.Save();
		}
	}
}

