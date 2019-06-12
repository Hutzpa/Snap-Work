using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetData;
using SnapWork.Models;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GetData;
using MySql.Data.MySqlClient;

namespace SnapWork.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Search : ContentPage
	{
        public List<Vacancy> Vacancies { get; set; }

        public List<TopVacancy> TopVacancies { get; set; }


        public Search ()
		{
			InitializeComponent ();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);

            Vacancies = VacanciesFill();

            Support.FillDropDown(JobPick, Support.jobList);
            Support.FillDropDown(PickCity, Support.cities);

            VacancyList.ItemsSource = Vacancies;

            DisplayAlert("Повідомлення", "Для того щоб занести вакансію в обране та назад, її треба виділити", "Ок");

        }

        private List<Vacancy> VacanciesFill()
        {
            List<Vacancy> vacancies = new List<Vacancy>();//= GetVacs(40);
            for(int i = 0; i < 10; i++)
            {
                vacancies.Add(new Vacancy
                {
                    IdVacancy = i,
                    IdUserPlacement = i,
                    Photo = "bla.jpg",
                    NameVacancy = "Урановые шахты" + i,
                    IdTypeJob = i,
                    Payment = i,
                    City = "Kharkov" + i,
                    DatePlacement = DateTime.Now,
                    Description = "Буй соси, губой тряси" + i,
                    VacancyState = VacancyState.Activated,
                    VacanceFormed = VacancyFormed.NotFormed
                });
            }

            //Здеся я получаю данные из бд

            return vacancies;

        }

        private void VacancyList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync((Page)Activator.CreateInstance(typeof(Vacantion), Regime.ForWorker, e.Item as Vacancy));
        }

        private void FavorBut_Clicked(object sender, EventArgs e)
        {

            Vacancy v = VacancyList.SelectedItem as Vacancy;


                ClassFavorites favorites = new ClassFavorites();
            //BorderWidth служит переключателем для кнопки избранного
            ImageButton imageButton = (ImageButton)sender;
            if (imageButton.BorderWidth == 1)
            {
                imageButton.Source = "FullStar.png";
                imageButton.BorderWidth = 0;

                //Добавить в избранное

                Favorites favor = new Favorites()
                {
                    IdAccount = AccountManager.Account.IdAccount,
                    IdVacancy = v.IdVacancy
                };
                favorites.InsertFavorites(favor);

            }
            else
            {
                imageButton.Source = "EmptyStar.png";
                imageButton.BorderWidth = 1;
                Favorites favor = new Favorites()
                {
                    IdAccount = AccountManager.Account.IdAccount,
                    IdVacancy = v.IdVacancy
                };
                favorites.DeleteFavorites(favor);
            }

        }

        private List<Vacancy> GetVacs(int amount)
        {
            // Запрос
            string query = string.Format("SELECT * FROM Vacancy");
            List<Vacancy> vacancy;

            using (MySqlConnection myConnection = new MySqlConnection(ConnectionStr.connectionString))
            {
                vacancy = new List<Vacancy>();
                try
                {
                    using (MySqlCommand command = new MySqlCommand(query, myConnection))
                    {
                        myConnection.Open();
                        MySqlDataReader reader = command.ExecuteReader();

                        int i = 0;

                        while (reader.Read() || i < amount )
                        {

                            vacancy.Add(new Vacancy
                            {
                                IdVacancy = Convert.ToInt32(reader["id_vacancy"]),
                                IdUserPlacement = Convert.ToInt32(reader["id_users"]),
                                Photo = reader["photo"].ToString(),
                                NameVacancy = reader["name_vacancy"].ToString(),
                                IdTypeJob = Convert.ToInt32(reader["id_type_job"]),
                                Payment = Convert.ToDecimal(reader["cost"]),
                                City = reader["city"].ToString(),
                                DatePlacement = Convert.ToDateTime(reader["dateAdd"]),
                                Description = reader["description"].ToString(),
                                VacancyState = (VacancyState)reader["active"],
                                VacanceFormed = (VacancyFormed)reader["formed"]
                            });
                            i++;
                        }
                        reader.Close();
                        myConnection.Close();
                    }
                }
                catch (Exception ex)
                {
                    //message = ex.Message;
                }
            }
            return vacancy;
        }

        private async void DelFavor(Favorites favorites)
        {
            // Запрос
            string query = string.Format("DELETE FROM Favorites WHERE id_vocation = @Id_Vacancy AND id_account= @Id_Account");
            try
            {
                await Task.Run(() =>
                {
                    using (MySqlConnection connection = new MySqlConnection(ConnectionStr.connectionString))
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            connection.Open();
                            MySqlParameter idParam = new MySqlParameter
                            {
                                ParameterName = "@Id_Vacancy",
                                Value = favorites.IdVacancy,
                                MySqlDbType = MySqlDbType.Int32
                            };
                            command.Parameters.Add(idParam);

                            MySqlParameter idAcc = new MySqlParameter
                            {
                                ParameterName = "@Id_Account",
                                Value = favorites.IdAccount,
                                MySqlDbType = MySqlDbType.Int32
                            };

                            command.Parameters.Add(idAcc);
                            // Добавляем параметр

                            // Выполняем запрос
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                DisplayAlert("Помилка", ex.Message, "Ок");
            }
        }
    }
}