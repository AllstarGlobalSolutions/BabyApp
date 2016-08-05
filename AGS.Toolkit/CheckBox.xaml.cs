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
		public static readonly BindableProperty TextProperty = BindableProperty.Create( "Text", typeof( string ), typeof( CheckBox ), null,
									propertyChanged: ( bindable, oldValue, newValue ) =>
									{
										( ( CheckBox )bindable ).textLabel.Text = ( string )newValue;
									} );

		public static readonly BindableProperty FontSizeProperty = BindableProperty.Create( "FontSize", typeof( double ), typeof( CheckBox ), Device.GetNamedSize( NamedSize.Default, typeof( Label ) ),
									propertyChanged: ( bindable, oldValue, newValue ) =>
									{
										CheckBox checkBox = ( ( CheckBox )bindable );
										checkBox.boxLabel.FontSize = ( double )newValue;
										checkBox.textLabel.FontSize = ( double )newValue;
									} );

		public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create( "IsChecked", typeof( bool ), typeof( CheckBox ), false,
									propertyChanged: ( bindable, oldValue, newValue ) =>
									{
										CheckBox checkBox = ( ( CheckBox )bindable );
										checkBox.textLabel.Text = ( bool )newValue ? "0u2611" : "0u2610";

										EventHandler<bool> eventHandler = checkBox.CheckedChanged;
										if ( eventHandler != null )
										{
											eventHandler( checkBox, ( bool )newValue );
										}
									} );

		public event EventHandler<bool> CheckedChanged;

		public CheckBox()
		{
			InitializeComponent();
		}
		
		public string Text
		{
			get { return ( string )GetValue( TextProperty ); }
			set { SetValue( TextProperty, value );  }
		}

		[TypeConverter( typeof( FontSizeConverter ) )]
		public double FontSize
		{
			get { return ( double )GetValue( FontSizeProperty ); }
			set { SetValue( FontSizeProperty, value ); }
		}

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
