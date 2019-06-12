using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using GetData;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnapWork.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OffersToMyVac : ContentPage
    {
        public ObservableCollection<OfrEl> Items { get; set; }


        public OffersToMyVac()
        {
            InitializeComponent();

            Items = FillPersons();
			
			MyListView.ItemsSource = Items;
        }

        [Obsolete("Метод не заполняет список претендентов на мою вакансию")]
        private ObservableCollection<OfrEl> FillPersons()
        {
            ObservableCollection<OfrEl> items= new ObservableCollection<OfrEl>();


            return items;

        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            OfrEl ofrEl = e.Item as OfrEl;
            Account acc = new Account()
            {
                IdAccount = ofrEl.IdAccount,
                NickName = ofrEl.NickName,
                Photo = ofrEl.Photo,
                Email = ofrEl.Email,
                BirthDay = ofrEl.BirthDay,
                Location = ofrEl.Location,
                Rate = Convert.ToDouble(ofrEl.Rate),
                TimeOnSite = ofrEl.TimeOnSite,
                Resume = ofrEl.Resume
            };

            await Navigation.PushAsync(new NavigationPage(new Facepage(acc)));


            
        }

        private void Accept_Clicked(object sender, EventArgs e)
        {
            // запись работника удалять из списка кандидатов и перемещать в список рабочих по вакансии
        }

        private void Deny_Clicked(object sender, EventArgs e)
        {
            // запись рабочего удалять из списка кандидатов
        }
    }

    public class OfrEl
    {
        public int IdAccount { get; set; }
        public string NickName { get; set; }
        [Obsolete]
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public string Location { get; set; }
        public decimal Rate { get; set; }
        public DateTime TimeOnSite { get; set; }
        public string Resume { get; set; }

        public int IdVacancy { get; set; }
        public string NameVacancy { get; set; }
    }
}
