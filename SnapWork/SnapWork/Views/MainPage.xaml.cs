using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


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

        private void Messages_clicked(object o, EventArgs e)
        {
            Detail.Navigation.PushAsync((Page)Activator.CreateInstance(typeof(Messages)));
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
            IsPresented = false;
        }
    }
}