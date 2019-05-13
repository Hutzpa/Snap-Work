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
	public partial class LogIn : ContentPage
	{
		public LogIn ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (CheckLogin())
            {
             Application.Current.MainPage = new MainPage();

            }
            else
            {
                LabelInvalid.IsVisible = true;
            }

        }

        private async void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        private async void ButtonReset_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RestorePassword());
        }

        [Obsolete("Логика проверки логина и пароля не написана")]
        private bool CheckLogin()
        {
            return true;
            /// логика 
        }
    }
}