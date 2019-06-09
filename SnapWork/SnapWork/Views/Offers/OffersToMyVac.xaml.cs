using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using SnapWork.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnapWork.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OffersToMyVac : ContentPage
    {
        public ObservableCollection<Account> Items { get; set; }


        public OffersToMyVac()
        {
            InitializeComponent();

            Items = FillPersons();
			
			MyListView.ItemsSource = Items;
        }

        [Obsolete("Метод не заполняет список претендентов на мою вакансию")]
        private ObservableCollection<Account> FillPersons()
        {
            ObservableCollection<Account> items= new ObservableCollection<Account>();


            return items;

        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
