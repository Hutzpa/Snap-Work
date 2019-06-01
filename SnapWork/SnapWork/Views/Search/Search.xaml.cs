using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryLibrary;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace SnapWork.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Search : ContentPage
	{
        public List<Vacancy> Vacancies { get; set; }

        public Search ()
		{
			InitializeComponent ();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);

            Vacancies = VacanciesFill();

            this.BindingContext = this;
            
        }

        private  void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }

        [Obsolete("Получение данных из бд не работает")]
        private List<Vacancy> VacanciesFill()
        {
            ClassVacancy vacancy = new ClassVacancy();
            List<Vacancy> vacancies = new List<Vacancy>()
            {
                new Vacancy{
                    idVacancy = 1,
                    idUserPlacement = 1,
                    photo = "bla.jpg",
                    nameVacancy = "Урановые шахты",
                    idTypeJob = 3,
                    payment = 453,
                    geoInfCity = "Kharkov",
                    datePlacement = DateTime.Now,
                    description = "Буй соси, губой тряси",
                    vacancyState = VacancyState.Activated,
                    vacanceFormed = VacancyFormed.NotFormed
                },
                new Vacancy{
                    idVacancy = 2,
                    idUserPlacement = 2,
                    photo = "bla.jpg",
                    nameVacancy = "Урановые шахты",
                    idTypeJob = 3,
                    payment = 453,
                    geoInfCity = "Kharkov",
                    datePlacement = DateTime.Now,
                    description = "Буй соси, губой тряси",
                    vacancyState = VacancyState.Activated,
                    vacanceFormed = VacancyFormed.NotFormed
                },
                new Vacancy{
                    idVacancy = 3,
                    idUserPlacement = 3,
                    photo = "bla.jpg",
                    nameVacancy = "Урановые шахты",
                    idTypeJob = 3,
                    payment = 453,
                    geoInfCity = "Kharkov",
                    datePlacement = DateTime.Now,
                    description = "Буй соси, губой тряси",
                    vacancyState = VacancyState.Activated,
                    vacanceFormed = VacancyFormed.NotFormed
                },
            };

            //Здеся я получаю данные из бд

            return vacancies;

        }

        private void VacancyList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Vacancy v = e.Item as Vacancy;
            DisplayAlert(v.nameVacancy, v.payment.ToString(), v.geoInfCity);
        }
    }
}