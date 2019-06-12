using GetData;
using Plugin.FilePicker;
using SnapWork.Models;
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

        private void Entry_Completed(object sender, EventArgs e)
        {

        }

        [Obsolete("Загрузка картинок не подключена")]
        private void Button_Clicked(object sender, EventArgs e)
        {
            ClassAccount classAccount = new ClassAccount();
            if (EntryLogin.Text != "")
            {
                AccountManager.Account.NickName = EntryLogin.Text;
            }
            if(EditorDescribe.Text != "")
            {
                //Обновление описания, С КАРТИНКОЙ ПО АНАЛОГИИ

            }

            classAccount.InsertAccount(AccountManager.Account);

            Application.Current.MainPage = new MainPage();
        }

        private async void ImagePicker_Clicked(object sender, EventArgs e)
        {
            var file = await CrossFilePicker.Current.PickFile();

            if (file != null)
            {
                UserAvatar.Source = file.FilePath;
                UserAvatar.IsVisible = true;
            }
        }
    }
}