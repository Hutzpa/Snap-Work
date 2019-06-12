using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetData;
using MySql.Data.MySqlClient;
using SnapWork.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnapWork.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Favorite : ContentPage
	{
        public List<Vacancy> Vacancies { get; set; }


        public Favorite ()
		{
			InitializeComponent ();
            Vacancies = VacanciesFill();

            this.BindingContext = this;
        }

        [Obsolete("Получение данных из бд не работает, избранные вакансии не считываються")]
        private List<Vacancy> VacanciesFill()
        {
            List<Favorites> favorites = SelectFavorites(AccountManager.Account.IdAccount);


            List<Vacancy> vacancies = new List<Vacancy>();
            //for (int i = 0; i < 10; i++)
            //{
            //    vacancies.Add(new Vacancy
            //    {
            //        IdVacancy = i,
            //        IdUserPlacement = i,
            //        Photo = "bla.jpg",
            //        NameVacancy = "Урановые шахты" + i,
            //        IdTypeJob = i,
            //        Payment = i,
            //        City = "Kharkov" + i,
            //        DatePlacement = DateTime.Now,
            //        Description = "Буй соси, губой тряси" + i,
            //        VacancyState = VacancyState.Activated,
            //        VacanceFormed = VacancyFormed.NotFormed
            //    });
            //}

            for(int i = 0; i < favorites.Count; i++)
            {
                vacancies.Add(SelectFavVacancy(favorites[i].IdVacancy));
            }

            //Здеся я получаю данные из бд

            return vacancies;

        }

        [Obsolete("Смотри комментарий")]
        private void VacancyList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //сделать статический массив с профессиями, чтоб передавать индекс в массиве
            Navigation.PushAsync((Page)Activator.CreateInstance(typeof(Vacantion), Regime.ForWorker, e.Item as Vacancy));
        }

        private void FavButton_Clicked(object sender, EventArgs e)
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
                // Удалить из избранного
                Favorites favor = new Favorites()
                {
                    IdAccount = AccountManager.Account.IdAccount,
                    IdVacancy = v.IdVacancy
                };
                favorites.DeleteFavorites(favor);
            }
        }


        /// <summary>
        /// Возврат конкретной записи
        /// </summary>
        /// <param name="query">Запрос</param> 
        /// <returns></returns>
        public Vacancy SelectFavVacancy(int id)
        {
            // Запрос
            string query = string.Format("SELECT * FROM Vacancy WHERE id_vacancy =" + id);
            Vacancy vacancy;

            using (MySqlConnection myConnection = new MySqlConnection(ConnectionStr.connectionString))
            {
                vacancy = new Vacancy();
                try
                {
                    using (MySqlCommand command = new MySqlCommand(query, myConnection))
                    {
                        myConnection.Open();
                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {

                            vacancy.IdVacancy = Convert.ToInt32(reader["id_vacancy"]);
                            vacancy.IdUserPlacement = Convert.ToInt32(reader["id_users"]);
                            vacancy.Photo = reader["photo"].ToString();
                            vacancy.NameVacancy = reader["name_vacancy"].ToString();
                            vacancy.IdTypeJob = Convert.ToInt32(reader["id_type_job"]);
                            vacancy.Payment = Convert.ToDecimal(reader["cost"]);
                            vacancy.City = reader["city"].ToString();
                            vacancy.DatePlacement = Convert.ToDateTime(reader["dateAdd"]);
                            vacancy.Description = reader["description"].ToString();
                            vacancy.VacancyState = (VacancyState)reader["active"];
                            vacancy.VacanceFormed = (VacancyFormed)reader["formed"];

                        }
                        reader.Close();
                        myConnection.Close();
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
            return vacancy;
        }

        public List<Favorites> SelectFavorites(int idPerson)
        {
            string query = string.Format("SELECT * FROM Favorites WHERE id_account = "+ idPerson);
            List<Favorites> favorites;

            using (MySqlConnection myConnection = new MySqlConnection(ConnectionStr.connectionString))
            {
                favorites = new List<Favorites>();
                try
                {
                    using (MySqlCommand command = new MySqlCommand(query, myConnection))
                    {
                        myConnection.Open();
                        // Создание и чтение строк, выполнение запроса
                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            favorites.Add(new Favorites
                            {
                                IdFavorites = Convert.ToInt32(reader["id_favorites"]),
                                IdAccount = Convert.ToInt32(reader["id_account"]),
                                IdVacancy = Convert.ToInt32(reader["id_vocation"]),
                            });
                        }

                        reader.Close();
                        myConnection.Close();
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return favorites;
        }
    }
}