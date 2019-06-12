using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GetData;
using SnapWork.Models;
using SnapWork.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnapWork.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResetPassword : ContentPage
    {
        public ResetPassword()
        {
            InitializeComponent();
        }


        private void EntryCurrent_Completed(object sender, EventArgs e)
        {
            CurPass.IsVisible = CheckIsPassRight() ? false : true; //Если пароль правильный, то ничего не выводит
        }


        private bool CheckIsPassRight()
        {
            if (EntryCurrent.Text == AccountManager.Account.Password)
            {
                return true;
            }
            return false;
        }

        private void EntryNewF_Completed(object sender, EventArgs e)
        {
            if (EntryNewF.Text.Length < 5)
            {
                NewPass.Text = "Парольне не може бути коротшим за 5 символів";
                NewPass.IsVisible = true;
            }
            else
            {
                NewPass.IsVisible = false;
            }
        }

        private void EntryNewS_Completed(object sender, EventArgs e)
        {
            if (EntryNewF.Text != EntryNewS.Text)
            {
                NewPass.Text = "Паролі не збігаються";
                NewPass.IsVisible = true;
            }
            else
            {
                NewPass.IsVisible = false;
            }

        }

        private async void ButtonApply_Clicked(object sender, EventArgs e)
        {
            //Проверить регулярки, могут возвращать неправиьльное значение
            if (CheckIsPassRight() || EntryNewF.Text.Length < 5 || EntryNewF.Text != EntryNewS.Text ||
                EntryCurrent.Text != "" || EntryNewF.Text != "" || EntryNewS.Text != "")
            {
                ClassAccount account = new ClassAccount();
                AccountManager.Account.Password = EntryNewF.Text;
                account.UpdateAccount(AccountManager.Account);

                await DisplayAlert("Повідомлення", "Пароль успішно змінено", "ОK");

                (new Messager()).SendMessage("user mail", "<h2>Шановний " + "КОРИСТУВАЧ" + " пароль до вашого аккаунту було успішно змінено. Якщо ви цього не робили, рекомендуємо якнайшвидше відновити пароль.</h2>");
            }
            else
            {
               await  DisplayAlert("Попередження", "Перевірте корректність введених данних", "ОK");
            }
        }
    }
}