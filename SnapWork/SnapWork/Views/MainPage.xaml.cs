using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SnapWork.Models;


namespace SnapWork.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;
            Detail = new NavigationPage(new Favorite());

            TapGestureRecognizer tap = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 2
            };

            tap.Tapped += (s, e) =>
            {
                Navigation.PushAsync(new NavigationPage(new Facepage(new Account())));
            };
            Avatar.GestureRecognizers.Add(tap);

        }


        private  void AddNew_clicked(object o, EventArgs e)
        {
            Detail.Navigation.PushAsync((Page)Activator.CreateInstance(typeof(AddNew)));
            IsPresented = false;
        }

        private void Search_clicked(object o, EventArgs e)
        {
            Detail.Navigation.PushAsync((Page)Activator.CreateInstance(typeof(SearchBoth)));
            IsPresented = false;
        }

        private  void Settings_clicked(object o, EventArgs e)
        {
            Detail.Navigation.PushAsync((Page)Activator.CreateInstance(typeof(Settings)));
            IsPresented = false;
        }

        private  void Vacantions_clicked(object o, EventArgs e)
        {
            Detail.Navigation.PushAsync((Page)Activator.CreateInstance(typeof(VacantionsAsWorker)));
            IsPresented = false;
        }

        private  void Favorite_clicked(object o, EventArgs e)
        {
            Detail.Navigation.PushAsync((Page)Activator.CreateInstance(typeof(Favorite)));
            //Detail.Navigation.PushAsync((Page)Activator.CreateInstance(typeof(Page1)));

            IsPresented = false;
        }

        private void ButtonOffers_Clicked(object sender, EventArgs e)
        {
            Detail.Navigation.PushAsync((Page)Activator.CreateInstance(typeof(Feedback)));
            //Detail.Navigation.PushAsync((Page)Activator.CreateInstance(typeof(Offer)));
            //Detail.Navigation.PushAsync((Page)Activator.CreateInstance(typeof(SearchPeople)));
            IsPresented = false;
        }
    }
}