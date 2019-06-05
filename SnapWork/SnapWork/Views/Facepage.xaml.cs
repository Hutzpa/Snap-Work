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
	public partial class Facepage : ContentPage
	{
		public Facepage (Account account)
		{
			InitializeComponent ();
            Avatar.Source = account.photo;
            UserName.Text = account.nickName;
            UserPhone.Text = account.phone;
            UserEmail.Text = account.email;
            UserRating.Text = account.rate.ToString();
            UserTimeOnSite.Text = account.timeOnSite.ToString();
            UserCity.Text = account.location;
            UserDesctiption.Text = account.resume;

            if (CheckUserReview())
            {
                IsReviewExist.IsVisible = true;

            }
            else
            {
                UserReview.IsVisible = false;
                UserReview.HeightRequest = 0;
                UserReview.IsEnabled = false;
            }
            
        }

        public Facepage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор для вызова  НЕ из поиска
        /// </summary>
        /// <param name="i"></param>
        public Facepage(int i)
        {
            InitializeComponent();
            CallWorker.IsVisible = false;
            CallWorker.HeightRequest = 0;
        }

        [Obsolete("Функционал 'позвать работника на вакансию' не реализован")]
        private void CallWorker_Clicked(object sender, EventArgs e)
        {
            //После нажатия 
        }

        private bool CheckUserReview()
        {
            /// проверяет, есть ли отзывы по этому пользователю
            return false;
        }
    }
}