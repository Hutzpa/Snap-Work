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
	public partial class VacantionsAsWorker : ContentPage
	{
        public ObservableCollection<Vacancy> Vacancies { get; set; }

        public VacantionsAsWorker ()
		{
			InitializeComponent ();

            Vacancies = VacanciesFill();

            this.BindingContext = this;
		}

        [Obsolete("Получение данных из бд не работает, мои вакансии не считываються")]
        private ObservableCollection<Vacancy> VacanciesFill()
        {
            ObservableCollection<Vacancy> vacancies = GetMyVacs(AccountManager.Account.IdAccount);
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

            
            
            return vacancies;

        }

        [Obsolete("Смотри комментарий")]
        private void VacancyList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //сделать статический массив с профессиями, чтоб передавать индекс в массиве
            Navigation.PushAsync((Page)Activator.CreateInstance(typeof(Vacantion),Regime.ForOwner,e.Item as Vacancy));
        }

        private ObservableCollection<Vacancy> GetMyVacs(int myId)
        {
            string query = string.Format("SELECT * FROM Vacancy WHERE id_users =" + myId);
            ObservableCollection<Vacancy> vacancy;

            using (MySqlConnection myConnection = new MySqlConnection(ConnectionStr.connectionString))
            {
                vacancy = new ObservableCollection<Vacancy>();
                try
                {
                    using (MySqlCommand command = new MySqlCommand(query, myConnection))
                    {
                        myConnection.Open();
                        MySqlDataReader reader = command.ExecuteReader();

                        int i = 0;
                        while (reader.Read())
                        {

                            vacancy[i].IdVacancy = Convert.ToInt32(reader["id_vacancy"]);
                            vacancy[i].IdUserPlacement = Convert.ToInt32(reader["id_users"]);
                            vacancy[i].Photo = reader["photo"].ToString();
                            vacancy[i].NameVacancy = reader["name_vacancy"].ToString();
                            vacancy[i].IdTypeJob = Convert.ToInt32(reader["id_type_job"]);
                            vacancy[i].Payment = Convert.ToDecimal(reader["cost"]);
                            vacancy[i].City = reader["city"].ToString();
                            vacancy[i].DatePlacement = Convert.ToDateTime(reader["dateAdd"]);
                            vacancy[i].Description = reader["description"].ToString();
                            vacancy[i].VacancyState = (VacancyState)reader["active"];
                            vacancy[i].VacanceFormed = (VacancyFormed)reader["formed"];
                            i++;
                        }
                        reader.Close();
                        myConnection.Close();
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("Помилка", ex.Message, "Ok");
                }
            }
            return vacancy;
        }
    }

    
}