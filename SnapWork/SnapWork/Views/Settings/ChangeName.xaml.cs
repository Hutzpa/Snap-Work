using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnapWork.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChangeName : ContentPage
	{
		public ChangeName ()
		{
			InitializeComponent ();
		}
        [Obsolete("Регулярка не написана, не происходит валидация")]
        private Regex loginValid = new Regex(" ");

        private void Entry_Completed(object sender, EventArgs e)
        {
            EntryLogin.TextColor = loginValid.IsMatch(EntryLogin.Text) ? Color.Red : Color.Green;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(EntryLogin.Text != "")
            { /// обновление логина
            }
            if(EditorDescribe.Text != "")
            {
                //Обновление описания, С КАРТИНКОЙ ПО АНАЛОГИИ

            }
            Application.Current.MainPage = new MainPage();
        }
    }
}