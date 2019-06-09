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
	public partial class ResetPassword : ContentPage
	{
		public ResetPassword ()
		{
			InitializeComponent ();
		}

        [Obsolete("Проверка не происходит, регулярка не написана")]
        Regex newPassValid = new Regex(" ");

        private void EntryCurrent_Completed(object sender, EventArgs e)
        {
            CurPass.IsVisible = CheckIsPassRight() ? true : false; //Если пароль правильный, то ничего не выводит
        }

        [Obsolete("Проверка правильности пароля не происходит")]
        private bool CheckIsPassRight()
        {
            //проверяет, правильный ли пароль
            return false;
        }

        private void EntryNewF_Completed(object sender, EventArgs e)
        {
            if (newPassValid.IsMatch(EntryNewF.Text))
            {
                NewPass.Text = "Пароль не может быть таким";
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
                NewPass.Text = "Пароли не совпадают";
                NewPass.IsVisible = true;
            }
            else
            {
                NewPass.IsVisible = false;
            }

        }

        [Obsolete("Пароль без изменений")]
        private void ButtonApply_Clicked(object sender, EventArgs e)
        {
            //Проверить регулярки, могут возвращать неправиьльное значение
            if(CheckIsPassRight()||!newPassValid.IsMatch(EntryNewF.Text) || EntryNewF.Text != EntryNewS.Text || 
                EntryCurrent.Text != " " || EntryNewF.Text != " " || EntryNewS.Text != " ")
            {
                //Изменить пароль
                (new Messager()).SendMessage("user mail", "<h2>Шановний " + "КОРИСТУВАЧ" + " пароль до вашого аккаунту було успішно змінено. Якщо ви цього не робили, рекомендуємо якнайшвидше відновити пароль.</h2>");
            }
            else
            {
                DisplayAlert("Предупреждение", "Проверьте правильность введённых данных", "ОK");
            }
        }
    }
}