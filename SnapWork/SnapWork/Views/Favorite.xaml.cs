using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnapWork.Models;


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

        [Obsolete("Смотри комментарий")]
        private void VacancyList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //сделать статический массив с профессиями, чтоб передавать индекс в массиве
            Navigation.PushAsync((Page)Activator.CreateInstance(typeof(Vacantion), Regime.ForWorker, e.Item as Vacancy));
        }

        private void FavButton_Clicked(object sender, EventArgs e)
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