using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AGS.Toolkit
{
	public class ExtendedLabel : Label
	{
		public ExtendedLabel()
		{
			SetLabelFontSize( ( double )PointSizeProperty.DefaultValue );
		}
		public static readonly BindableProperty PointSizeProperty = 
						BindableProperty.Create( "PointSize", typeof( double ), typeof( ExtendedLabel ), 8.0, propertyChanged: OnPointSizeChanged );

		public double PointSize
		{
			get { return ( double )GetValue( PointSizeProperty ); }
			set { SetValue( PointSizeProperty, value ); }
		}

		public static void OnPointSizeChanged( BindableObject bindable, object oldValue, object newValue )
		{
			( ( ExtendedLabel )bindable ).OnPointSizeChanged( ( double )oldValue, ( double )newValue );
		}

		public void OnPointSizeChanged( double oldValue, double newValue )
		{
			SetLabelFontSize( newValue );
		}

		public void SetLabelFontSize( double pointSize )
		{
			FontSize = 160 * pointSize / 72;
		}
	}
}
