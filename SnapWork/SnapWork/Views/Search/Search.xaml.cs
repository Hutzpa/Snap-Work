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


namespace SnapWork.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Search : ContentPage
	{
        public ObservableCollection<Vacancy> Vacancies { get; set; }

        public ObservableCollection<TopVacancy> TopVacancies { get; set; }


        public Search ()
		{
			InitializeComponent ();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);

            Vacancies = VacanciesFill();

            Support.FillDropDown(JobPick, Support.jobList);
            Support.FillDropDown(PickCity, Support.cities);

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
                    VacancyState = VacancyState.Activated,
                    VacanceFormed = VacancyFormed.NotFormed
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

        [Obsolete("В избранное не добавляеться")]
        private void FavorBut_Clicked(object sender, EventArgs e)
        {
            //BorderWidth служит переключателем для кнопки избранного
            ImageButton imageButton = (ImageButton)sender;
            if (imageButton.BorderWidth == 1)
            {
                imageButton.Source = "FullStar.png";
                imageButton.BorderWidth = 0;
                //Добавить в избранное
            }
            else
            {
                imageButton.Source = "EmptyStar.png";
                imageButton.BorderWidth = 1;
                // Удалить из избранного
            }

        }
    }
}