using GetData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnapWork.ViewModels;

using SnapWork.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GetData;
using System.Text.RegularExpressions;

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

        Regex validPhone = new Regex(@"^\d{12}$");

        Regex validEmail = new Regex(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$");

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
            LoginLength.Text = "Довжина імені " + LoginEntry.Text.Length + " /30";
        }

        private void LoginEntry_Completed(object sender, EventArgs e)
        {
           
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
           
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            if(!CheckIsEverythingFill())
            {
                DisplayAlert("Помилка", "Усі поля обов'язкові для заповнення", "Ок");
            }
            else if (!CheckIsEverythingRight())
            {
                DisplayAlert("Помилка", "Email чи телефон введено в невірному форматі", "Ок");
            }
            else
            {
                RegisterUser();
                DisplayAlert("Повідомлення", "Ви успішно зареєструвалися на сервісі SnapWork", "Ок");
                (new Messager()).SendMessage(EntryEmail.Text, "<h2>Шановний " + LoginEntry.Text + " дякуємо за реєстрацію у нашому сервісі.</h2>");
                Application.Current.MainPage = new NavigationPage(new LogIn());
            }
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


        private bool CheckIsEverythingFill()
        {
            if (LoginEntry.Text == "" || EntryPassword.Text == "" ||EntryPassword.Text.Length < 5 || EntryPhone.Text == "" || EntryEmail.Text == "" || PickerCity.SelectedItem == null)
            {
                
                return false;
            }
            return true;
        }

        private bool CheckIsEverythingRight()
        {
            if(!validPhone.IsMatch(EntryPhone.Text) || !validEmail.IsMatch(EntryEmail.Text))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Регистрирует пользователя
        /// </summary>
        [Obsolete("Метод не содержит реализации, RegisterUser не регистрирует")]
        private void RegisterUser()
        {
            Account newAcc = new Account()
            {
                NickName = LoginEntry.Text,
                Password = EntryPassword.Text,
                Phone = EntryPhone.Text,
                Email = EntryEmail.Text,
                BirthDay = Birthday.Date,
                Location = PickerCity.SelectedItem.ToString(),
                AmountOfMoney = 0,
                Rate = 0,
                TimeOnSite = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Resume = null,
            };
        }

    }
}