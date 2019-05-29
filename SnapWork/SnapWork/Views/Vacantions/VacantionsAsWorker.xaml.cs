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
	public partial class VacantionsAsWorker : ContentPage
	{
		public VacantionsAsWorker ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync((Page)Activator.CreateInstance(typeof(Vacantion), "balala"));


        }
    }
}