using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GetData;
using SnapWork.ViewModels;

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

        Regex validEmail = new Regex(@"^\d{12}$");



        private async void ButtonApply_Clicked(object sender, EventArgs e)
        {
            if (validEmail.IsMatch(EntryPhone.Text))
            {
                string pas = GenerateNewPass();

                GetData.ClassAccount classAccount = new ClassAccount();

                Account account = classAccount.SelectAccount(EntryPhone.Text);

                account.Password = pas;
                classAccount.UpdateAccount(account); 

                (new Messager()).SendMessage(EntryPhone.Text, account.NickName , pas); 

                await DisplayAlert("Відновлення паролю", "Новий пароль відправлений на Email","OK");
            }
            else
            {
                await DisplayAlert("Помилка", "Невірний формат телефону", "Ок");
            }
        }

        private string GenerateNewPass()
        {
            Random r = new Random();

            return "Klm" + r.Next(500, 5000) + "Z3ijKf" + r.Next(70000, 99000) + "PZPI1710B";
        }


        private async void EntryPhone_Completed(object sender, EventArgs e)
        {
            GetData.ClassAccount classAccount = new ClassAccount();

            Account account =  classAccount.SelectAccount(EntryPhone.Text);

            if (account.Phone == null)
            {
                await DisplayAlert("Помилка", "Цей телефон не прив'язаний до жодного аккаунту", "Ок");
                EntryPhone.Text = "";
            }
        }
    }
}