using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnapWork.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Messages : ContentPage
	{
		public Messages ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
           // Navigation.PushAsync(new NavigationPage( new Facepage()));
            Navigation.PushAsync((Page)Activator.CreateInstance(typeof(Facepage)));
        }
    }
}