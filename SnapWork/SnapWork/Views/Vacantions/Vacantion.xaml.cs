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
		public Vacantion ()
		{
			InitializeComponent ();
		}

        [Obsolete("Не отправляет запрос на вакансию, функция не реализована")]
        private void VacantionSendMyCand_Clicked(object sender, EventArgs e)
        {

        }

        
    }
}