using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AGS.Toolkit
{
	public partial class CheckBox : ContentView
	{
		public event EventHandler<bool> CheckedChanged;

		public CheckBox()
		{
			InitializeComponent();
		}

		// Text Property
		public static readonly BindableProperty TextProperty = BindableProperty.Create( "Text", typeof( string ), typeof( CheckBox ), null );
		public string Text
		{
			get { return ( string )GetValue( TextProperty ); }
			set { SetValue( TextProperty, value ); }
		}

		// TextColor property
		public static readonly BindableProperty TextColorProperty = BindableProperty.Create( "TextColor", typeof( Color ), typeof( CheckBox ), Color.Default );
		public Color TextColor
		{
			get { return ( Color )GetValue( TextColorProperty ); }
			set { SetValue( TextColorProperty, value ); }
		}

		// FontSize property
		public static readonly BindableProperty FontSizeProperty = BindableProperty.Create( "FontSize", typeof( double ), typeof( CheckBox ), Device.GetNamedSize( NamedSize.Default, typeof( Label ) ) );
		[TypeConverter( typeof( FontSizeConverter ) )]
		public double FontSize
		{
			get { return ( double )GetValue( FontSizeProperty ); }
			set { SetValue( FontSizeProperty, value ); }
		}

		// FontAttributes property
		public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create( "FontAttributes", typeof( FontAttributes ), typeof( CheckBox ), FontAttributes.None );
		public FontAttributes FontAttributes
		{
			get { return ( FontAttributes )GetValue( FontAttributesProperty ); }
			set { SetValue( FontAttributesProperty, value ); }
		}

		// IsChecked property
		public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create( "IsChecked", typeof( bool ), typeof( CheckBox ), false,
									propertyChanged: ( bindable, oldValue, newValue ) =>
									{
										CheckBox checkBox = ( ( CheckBox )bindable );

										EventHandler<bool> eventHandler = checkBox.CheckedChanged;
										if ( eventHandler != null )
										{
											eventHandler( checkBox, ( bool )newValue );
										}
									} );


		public bool IsChecked
		{
			get { return ( bool )GetValue( IsCheckedProperty ); }
			set { SetValue( IsCheckedProperty, value ); }
		}

		// TapGestureRecognizer handler
		public void OnCheckBoxTapped( object sender, EventArgs e)
		{
			IsChecked = !IsChecked;
		}
	}
}
