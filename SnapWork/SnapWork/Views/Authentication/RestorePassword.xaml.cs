using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        Regex validEmail = new Regex(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$");


        [Obsolete("Изменять так же запись в таблице с паролем")]
        private async void ButtonApply_Clicked(object sender, EventArgs e)
        {
            if (validEmail.IsMatch(EntryPhone.Text))
            {
                string pas = GenerateNewPass();
                //изменять сначала запись в таблице, а потом отсылать
                (new Messager()).SendMessage(EntryPhone.Text, "", pas); 

                await DisplayAlert("Відновлення паролю", "Пароль відправлений на Email","OK");
            }
            else
            {
                await DisplayAlert("Помилка", "Невірний формат email", "Ок");
            }
        }

        private string GenerateNewPass()
        {
            Random r = new Random();

            return "Klm" + r.Next(500, 5000) + "Z3ijKf" + r.Next(70000, 99000) + "PZPI1710B";
        }

        [Obsolete("Метод не реализован, сообщение с паролем не высылает")]
        private void RestorePasswordMotion()
        {

        }

        private void EntryPhone_Completed(object sender, EventArgs e)
        {
            
        }
    }
}