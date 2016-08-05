/* 
 NOTE:  This extension cannot be moved to the "toolkit" assembly because it must be in the same assembly as the resources (images)
*/
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BabyApp
{
	[ContentProperty( "Source" )]
	public class ImageResourceExtension : IMarkupExtension
	{
		public string Source { get; set; }

		public object ProvideValue( IServiceProvider serviceProvider )
		{
			if ( Source == null )
			{
				return null;
			}

			return ImageSource.FromResource( Source );
		}
	}
}
