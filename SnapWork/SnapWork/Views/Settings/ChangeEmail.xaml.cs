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
	public partial class ChangeEmail : ContentPage
	{
		public ChangeEmail ()
		{
			InitializeComponent ();
		}

        [Obsolete("Проверка Email не написана, валидациия не происходит")]
        Regex emailValid = new Regex(" ");

        private void EntryEmail_Completed(object sender, EventArgs e)
        {
            EntryEmail.TextColor = emailValid.IsMatch(EntryEmail.Text) ? Color.Red : Color.Green;
        } 

        private void ButtonApply_Clicked(object sender, EventArgs e)
        {
            if(EntryEmail.Text == "" || emailValid.IsMatch(EntryEmail.Text))
            {
                EntryEmail.Focus();
            }
            else
            {
                //Обновить мыло
                Application.Current.MainPage = new MainPage();
            }
        }
    }
}