using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetData;
using GetData;
using SnapWork.Models;
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

            //EntryLogin.Placeholder = ConnectionStr.connectionString;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (LoginExists())
            {
                Application.Current.MainPage = new MainPage();

            }
            else
            {
                DisplayError.IsVisible = true;
                LabelInvalid.IsVisible = true;
            }

        }


        private bool LoginExists()
        {
            GetData.ClassAccount classAccount = new ClassAccount();

            Account account = classAccount.SelectAccount(EntryLogin.Text);

            if(account.Phone == null || account.Password != EntryPassword.Text)
            {
               
                return false;
            }
            AccountManager.Account = account;
            return true;

        }

    }
}