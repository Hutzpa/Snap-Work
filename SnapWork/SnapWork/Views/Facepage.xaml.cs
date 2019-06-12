using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetData;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnapWork.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Facepage : ContentPage
	{
        /// <summary>
        /// Конструктор для вызова на вакансию
        /// </summary>
        /// <param name="account"></param>
		public Facepage (Account account)
		{
			InitializeComponent ();
            Avatar.Source = account.Photo;
            UserName.Text = account.NickName;
            UserPhone.Text = account.Phone;
            UserEmail.Text = account.Email;
            UserRating.Text = account.Rate.ToString();
            UserTimeOnSite.Text = account.TimeOnSite.ToString();
            UserCity.Text = account.Location;
            UserDesctiption.Text = account.Resume;
        }

        /// <summary>
        /// Конструктор для вызова  НЕ из поиска
        /// </summary>
        /// <param name="i"></param>
        public Facepage(Account account,int i)
        {
            InitializeComponent();

            Avatar.Source = account.Photo;
            UserName.Text = account.NickName;
            UserPhone.Text = account.Phone;
            UserEmail.Text = account.Email;
            UserRating.Text = account.Rate.ToString();
            UserTimeOnSite.Text = account.TimeOnSite.ToString();
            UserCity.Text = account.Location;
            UserDesctiption.Text = account.Resume;
            CallWorker.IsVisible = false;
            CallWorker.HeightRequest = 0;
        }

        [Obsolete("Функционал 'позвать работника на вакансию' не реализован")]
        private void CallWorker_Clicked(object sender, EventArgs e)
        {
            GetData.ClassListBids workerReq = new ClassListBids();
        }
    }
}