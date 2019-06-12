using GetData;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnapWork.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OffersToMe : ContentPage
    {
        public ObservableCollection<CustomVac> Items { get; set; }

        public OffersToMe()
        {
            InitializeComponent();

            Items = GetItems();
        }

        private ObservableCollection<CustomVac> GetItems()
        {
            return new ObservableCollection<CustomVac>();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            CustomVac cv = e.Item as CustomVac;
            Vacancy vacancy = new Vacancy
            {
                IdVacancy = cv.IdVacancy,
                IdUserPlacement = cv.IdUserPlacement,
                Photo = cv.Photo,
                NameVacancy = cv.NameVacancy,
                IdTypeJob = cv.IdTypeJob,
                Payment = cv.Payment,
                City = cv.City,
                DatePlacement = cv.DatePlacement,
                Description = cv.Description,
                VacancyState = cv.VacancyState,
                VacanceFormed = cv.VacanceFormed
            };

            await Navigation.PushAsync(new NavigationPage(new Vacantion(Regime.ForWorker, vacancy)));
        }

        private void Accept_Clicked(object sender, EventArgs e)
        {

        }

        private void Deny_Clicked(object sender, EventArgs e)
        {

        }
    }

    public class CustomVac
    {
        public int IdVacancy { get; set; }
        public int IdUserPlacement { get; set; }
        [Obsolete]
        public string Photo { get; set; }
        public string NameVacancy { get; set; }
        public int IdTypeJob { get; set; }
        public decimal Payment { get; set; }
        public string City { get; set; }
        public DateTime DatePlacement { get; set; }
        public string Description { get; set; }
        public VacancyState VacancyState { get; set; }
        public VacancyFormed VacanceFormed { get; set; }

        public int IdSpecialization { get; set; }
        public string Name { get; set; }
    }
}
