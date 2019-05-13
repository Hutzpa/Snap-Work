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
	public partial class RestorePassword : ContentPage
	{
		public RestorePassword ()
		{
			InitializeComponent ();
		}

        private async void ButtonApply_Clicked(object sender, EventArgs e)
        {
            RestorePasswordMotion();
            await DisplayAlert("Восстановление пароля", "Пароль выслан в SMS сообщении","OK");
        }


        [Obsolete("Метод не реализован, сообщение с паролем не высылает")]
        private void RestorePasswordMotion()
        {

        }
    }
}