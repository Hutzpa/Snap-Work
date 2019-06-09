using SnapWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnapWork.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnapWork.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Register : ContentPage
	{
		public Register ()
		{
			InitializeComponent ();

            Birthday.MaximumDate = DateTime.Now.AddYears(-18);
            Support.FillDropDown(PickerCity, Support.cities);
        }

        private void LoginEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(LoginEntry.Text.Length == LoginEntry.MaxLength)
            {
                LoginLength.TextColor = Color.Red;
                
            }
            else
            {
                LoginLength.TextColor = Color.Green;
            }
            LoginLength.Text = "Длина логина " + LoginEntry.Text.Length + " /30";
        }

        private void LoginEntry_Completed(object sender, EventArgs e)
        {
            if(!CheckLoginUnique())
            {
                LoginLength.Text = "Логин не уникальный, выберите другой";
                LoginLength.TextColor = Color.Red;
            }
            else
            {
                LoginLength.Text = "";
            }
        }

        private void EntryPhone_Completed(object sender, EventArgs e)
        {
            
            if (!CheckPhoneUnique())
            {
                PhoneLabel.Text = "Данный номен телефона уже зарегистрирован, выберите другой";
                PhoneLabel.TextColor = Color.Red;
            }
            else
            {
                PhoneLabel.Text = "";
            }
        }

        private void EntryEmail_Completed(object sender, EventArgs e)
        {
            if (!CheckEmainUnique())
            {
                EmailLabel.Text = "Данный номен телефона уже зарегистрирован, выберите другой";
                EmailLabel.TextColor = Color.Red;
            }
            else
            {
                EmailLabel.Text = "";
            }
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            if(!CheckIsEverythingFill())
            {
                //Сообщения об неверности ввода
            }
            else if (!CheckIsEverythingRight())
            {
                //Сообщения об неверности ввода
            }
            else
            {
                RegisterUser();
                (new Messager()).SendMessage(EntryEmail.Text, "<h2>Шановний " + LoginEntry.Text + " дякуємо за реєстрацію у нашому сервісі.</h2>");
            }
        }

        /// <summary>
        /// Проверяет уникальность логина
        /// </summary>
        /// <returns></returns>
        [Obsolete("Метод не содержит реализации, уникальность логина не проверяеться")]
        private bool CheckLoginUnique()
        {
            return true;
        }

        /// <summary>
        /// Проверяет уникальность телефона
        /// </summary>
        /// <returns></returns>
        [Obsolete("Метод не содержит реализации, уникальность телефона не проверяеться")]
        private bool CheckPhoneUnique()
        {
            return true;
        }

        /// <summary>
        /// Проверяет уникальность почты 
        /// </summary>
        /// <returns></returns>
        [Obsolete("Метод не содержит реализации, уникальность почты не проверяеться")]
        private bool CheckEmainUnique()
        {
            return true;
        }


        /// <summary>
        /// Проверяет, все ли поля заполнены
        /// </summary>
        /// <returns></returns>
        [Obsolete("Метод не содержит реализации, CheckIsEverythingFill не проверяет")]
        private bool CheckIsEverythingFill()
        {
            return true;
        }

        /// <summary>
        /// Проверяет, все ли поля заполнены правильно
        /// </summary>
        /// <returns></returns>
        [Obsolete("Метод не содержит реализации, CheckIsEverythingRight не проверяет")]
        private bool CheckIsEverythingRight()
        {
            return true;
        }

        /// <summary>
        /// Регистрирует пользователя
        /// </summary>
        [Obsolete("Метод не содержит реализации, RegisterUser не регистрирует")]
        private void RegisterUser()
        {

        }

    }
}