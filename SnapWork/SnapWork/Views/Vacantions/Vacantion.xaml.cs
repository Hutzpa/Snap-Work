using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetData;
using SnapWork.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnapWork.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Vacantion : ContentPage
	{
       public List<Account> Workers { get; set; }
        public Vacantion(Regime regime,Vacancy v)
        {
            InitializeComponent();
            this.Title = v.NameVacancy;

            curVacancy = v;

            Fill(v.Photo,v.NameVacancy, v.IdTypeJob.ToString(), v.Payment.ToString(), v.City, v.Description);
            switch (regime)
            {
                case Regime.ForOwner:
                    {
                        VacantionSendMyCand.IsEnabled = false;
                        VacantionSendMyCand.IsVisible = false;
                        VacantionSendMyCand.HeightRequest = 0;
                        break;
                    }
                case Regime.ForWorker:
                    {
                        RedactButtons.IsEnabled = false;
                        RedactButtons.IsVisible = false;
                        RedactButtons.HeightRequest = 0;
                      
                        break;
                    }
            }
        }

        Vacancy curVacancy;

        public Vacantion()
        {
            InitializeComponent();
        }

        [Obsolete("Список работников не выводиться")]
        private List<Vacancy> WorkersOnThisVacancy()
        {
            return new List<Vacancy>();
        }

        public void Fill(string imagePath, string title, string typeoOfWork, string payment, string city, string description)
        {
            Title = title;

            VacantPhoto.Source = imagePath;
            VacantTitle.Text = title;
            VacantionTypeOfWork.Text = typeoOfWork;
            VacantionPayment.Text = payment;
            VacantionCity.Text = city;
            VacantionDescription.Text = description;
        }

        private void VacantionSendMyCand_Clicked(object sender, EventArgs e)
        {
            ClassListBids classListBids = new ClassListBids();

            ListOfBids listOfBids = new ListOfBids()
            {
                IdAccount = AccountManager.Account.IdAccount,
                IdVacancy = curVacancy.IdVacancy

            };

            classListBids.InsertListBids(listOfBids);
        }

        [Obsolete("Проверить выполнение метода")]
        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync((Page)Activator.CreateInstance(typeof(AddNew), VacantPhoto.Source, VacantTitle.Text, VacantionTypeOfWork.Text, VacantionPayment.Text, VacantionCity.Text,0, VacantionDescription.Text));
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            bool selection = await DisplayAlert("Подтвердить действие", "Удалить вакансию? \n Это действие нельзя отменить. ", "Да", "Нет");
            if (selection)
            {
                await Navigation.PushAsync(new NavigationPage(new Feedback(AccountManager.Account.IdAccount, curVacancy.IdVacancy)));

                ClassVacancy classVacancy = new ClassVacancy();
                classVacancy.DeleteVacancy(curVacancy);

                Application.Current.MainPage = (Page)Activator.CreateInstance(typeof(VacantionsAsWorker));

            }
        }

        [Obsolete("Метод не закончен, смена статуса вакансии не происходит")]
        private async void FormingOver_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Повідомлення", "Ця функія знаходиться на стадії реалізації", "Ок");
        }
    }
}