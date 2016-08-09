using System;
using AGS.Toolkit;

namespace BabyApp.ViewModels
{
	public class NeedViewModel : ViewModelBase
	{
		Guid needId, organizationId;
		string caption, story, imageUrl, city, country, region, organizationName, organizationBacgroundInfo, needType, tags;
		decimal needAmount;

		public string Caption
		{
			get { return caption; }
			set { SetProperty( ref caption, value ); }
		}

		public string Story
		{
			get { return caption; }
			set { SetProperty( ref caption, value ); }
		}

		public string ImageUrl
		{
			get { return imageUrl; }
			set { SetProperty( ref imageUrl, value ); }
		}

		public decimal NeedAmount
		{
			get { return needAmount; }
			set { SetProperty( ref needAmount, value ); }
		}

		public string City
		{
			get { return city; }
			set { SetProperty( ref city, value ); }
		}

		public string Country
		{
			get { return country; }
			set { SetProperty( ref country, value ); }
		}

		public string Region
		{
			get { return region; }
			set { SetProperty( ref region, value ); }
		}

		public string OrganizationName
		{
			get { return organizationName; }
			set { SetProperty( ref organizationName, value ); }
		}

		public string OrganizationBackgroundInfo
		{
			get { return organizationBacgroundInfo; }
			set { SetProperty( ref organizationBacgroundInfo, value ); }
		}

		public string NeedType
		{
			get { return needType; }
			set { SetProperty( ref needType, value ); }
		}

		public string Tags
		{
			get { return tags; }
			set { SetProperty( ref tags, value ); }
		}
	}
}

