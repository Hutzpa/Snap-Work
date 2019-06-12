using GetData;
using SnapWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnapWork.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChangeEmail : ContentPage
	{
		public ChangeEmail ()
		{
			InitializeComponent ();
		}

        [Obsolete("Проверка Email не написана, валидациия не происходит")]
        Regex emailValid = new Regex(@"^ ([a - z0 - 9_ -] +\.) *[a - z0 - 9_ -] +@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$");

        private void EntryEmail_Completed(object sender, EventArgs e)
        {
            EntryEmail.TextColor = emailValid.IsMatch(EntryEmail.Text) ? Color.Red : Color.Green;
        } 

        [Obsolete("Мыло не изменяеться")]
        private void ButtonApply_Clicked(object sender, EventArgs e)
        {
            if(EntryEmail.Text == "" || emailValid.IsMatch(EntryEmail.Text))
            {
                DisplayAlert("Помилка", "Невірни формат email", "Ок");
            }
            else
            {
                ClassAccount classAccount = new ClassAccount();
                AccountManager.Account.Email = EntryEmail.Text;

                classAccount.UpdateAccount(AccountManager.Account);

                DisplayAlert("Повідомлення", "Еmail змінено", "Ок");
            }
        }
    }
}