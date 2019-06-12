using System;
using System.Threading.Tasks;
using SnapWork.ViewModels;


using GetData;
using SnapWork.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;


using MySql.Data.MySqlClient;

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
                PhoneLabel.Text = "Цей номер телефону вже був зарєстрований, виберіть інший";
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

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            if(!CheckIsEverythingFill())
            {
                await DisplayAlert("Помилка", "Усі поля обов'язкові для заповнення", "Ок");
            }
            else if (!CheckIsEverythingRight())
            {
                await DisplayAlert("Помилка", "Email чи телефон введено в невірному форматі", "Ок");
            }
            else
            {
                RegisterUser();
                await DisplayAlert("Повідомлення", "Ви успішно зареєструвалися на сервісі SnapWork", "Ок");
                (new Messager()).SendMessage(EntryEmail.Text, "<h2>Шановний " + LoginEntry.Text + " дякуємо за реєстрацію у нашому сервісі.</h2>");
                Application.Current.MainPage = new NavigationPage(new LogIn());
            }
        }

        private bool CheckPhoneUnique()
        {
            GetData.ClassAccount classAccount = new ClassAccount();

            Account account = classAccount.SelectAccount(EntryPhone.Text);

            if (account.Phone != null)
            {
                return false;
            }
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
            if(!validPhone.IsMatch(EntryPhone.Text) || !validEmail.IsMatch(EntryEmail.Text) || !CheckPhoneUnique())
            {
                return false;
            }
            return true;
        }


        private void RegisterUser()
        {
            Account newAcc = new Account()
            {
               
                NickName = LoginEntry.Text,
                Photo = " ",
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

            ClassAccount classAccount = new ClassAccount();

            InsertAccount(newAcc);
            //classAccount.InsertAccount(newAcc);

        }

        async public void InsertAccount(Account account)
        {
            // Переменная хранящая запрос
            string query = string.Format("INSERT INTO Account" + "(id_account, nickname, photo, password, telephone, email, birthday, money, location, rate, timeOnSite, resume)" +
                "VALUES(@IdAccount, @Nick, @Photo, @Password, @Phone, @Mail, @BirthDay, @AmountOfMoney, @Location, @Rate, @TimeOnSite, @Resume)");

            try
            {
                // Ассинхронная операция с помощью лямбда - выражения
                await Task.Run(() =>
                {
                    using (MySqlConnection connection = new MySqlConnection(ConnectionStr.connectionString))
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {

                            connection.Open();
                            // Параметры для выполнения
                            MySqlParameter idAccountParam = new MySqlParameter
                            {
                                ParameterName = "@IdAccount",
                                Value = account.IdAccount,
                                MySqlDbType = MySqlDbType.Int32
                            };
                            // Добавляем параметр
                            command.Parameters.Add(idAccountParam);

                            MySqlParameter nickParam = new MySqlParameter
                            {
                                ParameterName = "@Nick",
                                Value = account.NickName,
                                MySqlDbType = MySqlDbType.String
                            };
                            // Добавляем параметр
                            command.Parameters.Add(nickParam);

                            MySqlParameter photoParam = new MySqlParameter
                            {
                                ParameterName = "@Photo",
                                Value = account.Photo,
                                MySqlDbType = MySqlDbType.String,
                            };
                            // Добавляем параметр
                            command.Parameters.Add(photoParam);

                            MySqlParameter pasParam = new MySqlParameter
                            {
                                ParameterName = "@Password",
                                Value = account.Password,
                                MySqlDbType = MySqlDbType.String
                            };
                            // Добавляем параметр
                            command.Parameters.Add(pasParam);

                            MySqlParameter phoneParam = new MySqlParameter
                            {
                                ParameterName = "@Phone",
                                Value = account.Phone,
                                MySqlDbType = MySqlDbType.String
                            };
                            // Добавляем параметр
                            command.Parameters.Add(phoneParam);

                            MySqlParameter mailParam = new MySqlParameter
                            {
                                ParameterName = "@Mail",
                                Value = account.Email,
                                MySqlDbType = MySqlDbType.String
                            };
                            // Добавляем параметр
                            command.Parameters.Add(mailParam);

                            MySqlParameter birthDayParam = new MySqlParameter
                            {
                                ParameterName = "@BirthDay",
                                Value = account.BirthDay,
                                MySqlDbType = MySqlDbType.DateTime
                            };
                            // Добавляем параметр
                            command.Parameters.Add(birthDayParam);

                            MySqlParameter amountOfMoneyParam = new MySqlParameter
                            {
                                ParameterName = "@AmountOfMoney",
                                Value = account.AmountOfMoney,
                                MySqlDbType = MySqlDbType.Decimal
                            };
                            // Добавляем параметр
                            command.Parameters.Add(amountOfMoneyParam);

                            MySqlParameter locationParam = new MySqlParameter
                            {
                                ParameterName = "@Location",
                                Value = account.Location,
                                MySqlDbType = MySqlDbType.String
                            };
                            // Добавляем параметр
                            command.Parameters.Add(locationParam);


                            MySqlParameter rateParam = new MySqlParameter
                            {
                                ParameterName = "@Rate",
                                Value = account.Rate,
                                MySqlDbType = MySqlDbType.Double
                            };
                            // Добавляем параметр
                            command.Parameters.Add(rateParam);

                            MySqlParameter timeOnSiteParam = new MySqlParameter
                            {
                                ParameterName = "@TimeOnSite",
                                Value = account.TimeOnSite,
                                MySqlDbType = MySqlDbType.DateTime
                            };
                            // Добавляем параметр
                            command.Parameters.Add(timeOnSiteParam);

                            MySqlParameter resumeParam = new MySqlParameter
                            {
                                ParameterName = "@Resume",
                                Value = account.Resume,
                                MySqlDbType = MySqlDbType.String
                            };
                            // Добавляем параметр
                            command.Parameters.Add(resumeParam);


                            // Выполняем sql - запрос
                            command.ExecuteNonQuery();
                            connection.Close();

                        }
                    }
                });
            }
            catch (Exception ex)
            {
                DisplayAlert("Помилка", ex.Message, "Ok");
            }
        }

    }


}