using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnapWork.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPeople : ContentPage
    {
        public ObservableCollection<Account> People { get; set; }

        public SearchPeople()
        {
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);

            People = FillPeople();
            this.BindingContext = this;
        }


        private ObservableCollection<Account> FillPeople()
        {
            //нужно получать последнии специальности каждого рабочего
            ObservableCollection<Account> vacancies = new ObservableCollection<Account>();
            for (int i = 0; i < 10; i++)
            {
                vacancies.Add(new Account
                {
                    nickName = "Ivan" + i,
                    photo = "bla.jpg",
                    location = "Kharkov" + i,
                    amountOfMoney = i

                });
            }

            return vacancies;
        }

        private void WorkersList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync((Page)Activator.CreateInstance(typeof(Facepage),e.Item as Account));
        }
    }
}