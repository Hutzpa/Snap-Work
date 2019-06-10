using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetData;
using GetData;

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

            TapGestureRecognizer tapGestureReg = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 2
            };

            tapGestureReg.Tapped += (s, e) =>
            {                
                Navigation.PushAsync(new Register());
            };
            LabelRegister.GestureRecognizers.Add(tapGestureReg);

            TapGestureRecognizer tapGestureRestor = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 2
            };

            tapGestureRestor.Tapped += (s, e) =>
            {
                    Navigation.PushAsync(new RestorePassword());
            };
            LabelRestore.GestureRecognizers.Add(tapGestureRestor);

            //ConnectionStr.connectionString
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (LoginExists())
            {
               // ClassAccount log = new ClassAccount();
               // Account acc = log.
                Application.Current.MainPage = new MainPage();

            }
            else
            {
                DisplayError.IsVisible = true;
                LabelInvalid.IsVisible = true;
            }

        }

        [Obsolete("Логика проверки логина и пароля не написана")]
        private bool LoginExists()
        {

            return true;
            /// логика 
        }

    }
}