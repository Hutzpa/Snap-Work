using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SnapWork.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SnapWork
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //Я или всё сломаю, или всё починю
            MainPage = new NavigationPage(new LogIn());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
