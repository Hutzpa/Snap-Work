using System;
using System.Collections.Generic;
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
    public partial class Facepage : ContentPage
    {
        /// <summary>
        /// Конструктор для вызова на вакансию
        /// </summary>
        /// <param name="account"></param>
		public Facepage(Account account)
        {
            InitializeComponent();
            Avatar.Source = account.Photo;
            UserName.Text = account.NickName;
            UserPhone.Text = account.Phone;
            UserEmail.Text = account.Email;
            UserRating.Text = account.Rate.ToString();
            UserTimeOnSite.Text = account.TimeOnSite.ToString();
            UserCity.Text = account.Location;
            UserDesctiption.Text = account.Resume;
        }

        /// <summary>
        /// Конструктор для вызова  НЕ из поиска
        /// </summary>
        /// <param name="i"></param>
        public Facepage(Account account, int i)
        {
            InitializeComponent();

            Avatar.Source = account.Photo;
            UserName.Text = account.NickName;
            UserPhone.Text = account.Phone;
            UserEmail.Text = account.Email;
            UserRating.Text = account.Rate.ToString();
            UserTimeOnSite.Text = account.TimeOnSite.ToString();
            UserCity.Text = account.Location;
            UserDesctiption.Text = account.Resume;
            CallWorker.IsVisible = false;
            CallWorker.HeightRequest = 0;
            MyVacantions.IsVisible = false;
            MyVacantions.HeightRequest = 0;
        }

        private void CallWorker_Clicked(object sender, EventArgs e)
        {
            GetData.ClassListBids workerReq = new ClassListBids();

            List<Vacancy> vacancies = FillMyVacs(AccountManager.Account.IdAccount);

            vacancies = (new ClassVacancy()).SelectVacancy();

            ListOfBids listOfBids = new ListOfBids()
            {
                IdAccount = AccountManager.Account.IdAccount,
                IdVacancy = vacancies[MyVacantions.SelectedIndex].IdVacancy
            };

            workerReq.InsertListBids(listOfBids);
        }


        private List<Vacancy> FillMyVacs(int id)
        {
            // Запрос
            string query = string.Format("SELECT * FROM Vacancy WHERE id_users =" + id);
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

                        while (reader.Read())
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
    }
}