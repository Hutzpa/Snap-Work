using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryLibrary;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnapWork.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Favorite : ContentPage
	{
        public ObservableCollection<Vacancy> Vacancies { get; set; }


        public Favorite ()
		{
			InitializeComponent ();
            Vacancies = VacanciesFill();

            this.BindingContext = this;
        }

        [Obsolete("Получение данных из бд не работает, избранные вакансии не считываються")]
        private ObservableCollection<Vacancy> VacanciesFill()
        {
            ObservableCollection<Vacancy> vacancies = new ObservableCollection<Vacancy>();
            for (int i = 0; i < 10; i++)
            {
                vacancies.Add(new Vacancy
                {
                    idVacancy = i,
                    idUserPlacement = i,
                    photo = "bla.jpg",
                    nameVacancy = "Урановые шахты" + i,
                    idTypeJob = i,
                    payment = i,
                    city = "Kharkov" + i,
                    datePlacement = DateTime.Now,
                    description = "Буй соси, губой тряси" + i,
                    vacancyState = VacancyState.Activated,
                    vacanceFormed = VacancyFormed.NotFormed
                });
            }

            //Здеся я получаю данные из бд

            return vacancies;

        }

        private void VacancyList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Vacancy v = e.Item as Vacancy;
            //сделать статический массив с профессиями, чтоб передавать индекс в массиве
            Navigation.PushAsync((Page)Activator.CreateInstance(typeof(Vacantion), Regime.ForWorker, v.photo, v.nameVacancy, v.idTypeJob.ToString(), v.payment.ToString(), v.city, v.description));
            //Navigation.PushAsync(new NavigationPage(new Vacantion()));
        }
    }
}