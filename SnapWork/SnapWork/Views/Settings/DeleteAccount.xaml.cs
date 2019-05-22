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
            bool selection = await DisplayAlert("Подтвердить действие", "Удалить аккаунт? \n Это действие нельзя отменить. ", "Да", "Нет");
            if (selection)
            {
                //Удалить аккаунт
                Application.Current.MainPage = new NavigationPage(new LogIn());
            }
        }
    }
}