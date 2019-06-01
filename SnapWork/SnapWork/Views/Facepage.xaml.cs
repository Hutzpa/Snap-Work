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
		public Facepage ()
		{
			InitializeComponent ();
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
    }
}