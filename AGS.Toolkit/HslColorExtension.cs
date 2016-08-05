using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AGS.Toolkit
{
	public class HslColorExtension : IMarkupExtension
	{
		public double H { get; set; }
		public double S { get; set; }
		public double L { get; set; }
		public double A { get; set; }

		public HslColorExtension()
		{
			A = 1;
		}

		public object ProvideValue( IServiceProvider serviceProvider )
		{
			return Color.FromHsla( H, S, L, A );
		}
	}
}
