using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnapWork.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Vacantion : ContentPage
	{

        public Vacantion(Regime regime,string imagePath,string title,string typeoOfWork,string payment,string city,string description)
        {
            InitializeComponent();

            Fill(imagePath,title, typeoOfWork, payment, city,description);
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

        public Vacantion()
        {
            InitializeComponent();
        }

        [Obsolete("Метод не содержит реализации")]
        public void Fill(string imagePath, string title, string typeoOfWork, string payment, string city, string description)
        {
            VacantPhoto.Source = imagePath;
            VacantTitle.Text = title;
            VacantionTypeOfWork.Text = typeoOfWork;
            VacantionPayment.Text = payment;
            VacantionCity.Text = city;
            VacantionDescription.Text = description;
        }

        [Obsolete("Не отправляет запрос на вакансию, функция не реализована")]
        private void VacantionSendMyCand_Clicked(object sender, EventArgs e)
        {

        }

        [Obsolete("Проверить выполнение метода")]
        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync((Page)Activator.CreateInstance(typeof(AddNew), VacantPhoto.Source, VacantTitle.Text, VacantionTypeOfWork.Text, VacantionPayment.Text, VacantionCity.Text,0, VacantionDescription.Text));
        }

        [Obsolete("Метод не закончен")]
        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            bool selection = await DisplayAlert("Подтвердить действие", "Удалить вакансию? \n Это действие нельзя отменить. ", "Да", "Нет");
            if (selection)
            {
                //Удалить вакансию
                Application.Current.MainPage = (Page)Activator.CreateInstance(typeof(VacantionsAsWorker));

            }
        }

        [Obsolete("Метод не закончен, смена статуса вакансии не происходит")]
        private void FormingOver_Clicked(object sender, EventArgs e)
        {

        }
    }
}