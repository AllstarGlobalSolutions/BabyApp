using System;
using AGS.Toolkit;

namespace BabyApp.ViewModels
{
	public class NeedViewModel : ViewModelBase
	{
		//		Guid needId, organizationId;
		string caption, story, image1Url, image2Url, city, country, region, organizationName, organizationInfo, needType, tags;
		decimal needAmount;

		public string Caption
		{
			get { return caption; }
			set { SetProperty( ref caption, value ); }
		}

		public string Story
		{
			get { return story; }
			set { SetProperty( ref story, value ); }
		}

		public string Image1Url
		{
			get { return image1Url; }
			set { SetProperty( ref image1Url, value ); }
		}

		public string Image2Url
		{
			get { return image2Url; }
			set { SetProperty( ref image2Url, value ); }
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

		public string OrganizationInfo
		{
			get { return organizationInfo; }
			set { SetProperty( ref organizationInfo, value ); }
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

