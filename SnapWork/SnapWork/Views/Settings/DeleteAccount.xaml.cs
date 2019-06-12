using GetData;
using SnapWork.Models;
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
	public partial class DeleteAccount : ContentPage
	{
		public DeleteAccount ()
		{
			InitializeComponent ();
		}

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            bool selection = await DisplayAlert("Підтвердити дію", "Видалити аккаунт? \n Цю дію не можна буде відмінити", "Так", "Ні");
            if (selection)
            {
                ClassAccount account = new ClassAccount();
                account.DeleteAccount(AccountManager.Account);
                Application.Current.MainPage = new NavigationPage(new LogIn());
            }
        }
    }
}