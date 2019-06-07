using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetData;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace SnapWork.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Search : ContentPage
	{
        public ObservableCollection<Vacancy> Vacancies { get; set; }

        public Search ()
		{
			InitializeComponent ();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);

            Vacancies = VacanciesFill();



            VacancyList.ItemsSource = Vacancies;


        }

        [Obsolete("Получение данных из бд не работает")]
        private ObservableCollection<Vacancy> VacanciesFill()
        {
            ObservableCollection<Vacancy> vacancies = new ObservableCollection<Vacancy>();
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
                    VacancyState = GetData.VacancyState.Activated,
                    VacanceFormed = GetData.VacancyFormed.NotFormed
                });
            }

            //Здеся я получаю данные из бд

            return vacancies;

        }

        private void VacancyList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //Vacancy v = e.Item as Vacancy;
            Navigation.PushAsync((Page)Activator.CreateInstance(typeof(Vacantion), Regime.ForWorker, e.Item as Vacancy));
        }
    }
}