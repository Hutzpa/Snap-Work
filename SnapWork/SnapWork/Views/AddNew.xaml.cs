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
	public partial class AddNew : ContentPage
	{
		public AddNew ()
		{
			InitializeComponent ();

            PickerInitializer();

        }

        private Regex entryValidation = new Regex(" ");

        private Regex onlyDigitsValid = new Regex(" ");

        private string moneyType = "₴";
        private string city = " ";

        [Obsolete("Отсутствует регулярное выражение")]
        private void EntryName_TextChanged(object sender, TextChangedEventArgs e)
        {
            MaxCount.IsVisible = true;
            MaxNumb.Text = EntryName.Text.Length.ToString();

            MaxNumb.TextColor = EntryName.Text.Length == EntryName.MaxLength ? Color.Red : Color.Green;

            if (entryValidation.IsMatch(EntryName.Text))
            {
                MaxNumb.Text = "Некорректное название";
                MaxNumb.TextColor = Color.Red;

            }
        }

        [Obsolete("Этот метод не закончен и не содержит реализации") ]
        private void PickerInitializer()
        {

        }

        private void PickerMoneyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            moneyType = picker.SelectedItem.ToString();
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var switcher = (Switch)sender;

            PickerCity.IsVisible = switcher.IsToggled ? false : true;
        }

        private void PickerCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            city = picker.SelectedItem.ToString();
        }

        private void Switch_Toggled_1(object sender, ToggledEventArgs e)
        {
            var switcher = (Switch)sender;
            if(switcher.IsToggled)
            {
                EntryAmountOfWorkers.IsVisible = false;
                LabelCountOfPersons.IsVisible = false;
            }
            else
            {
                EntryAmountOfWorkers.IsVisible = true;
                LabelCountOfPersons.IsVisible = true;
            }
        }

        private void EntryAmountOfWorkers_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (onlyDigitsValid.IsMatch(EntryAmountOfWorkers.Text))
            {
                EntryAmountOfWorkers.TextColor = Color.Red;
            }
            else
            {
                EntryAmountOfWorkers.TextColor = Color.Black;
            }

        }

        private void EntryPayment_TextChanged(object sender, TextChangedEventArgs e)
        {
            EntryPayment.TextColor = onlyDigitsValid.IsMatch(EntryPayment.Text) ? Color.Red : Color.Black;
            //if (onlyDigitsValid.IsMatch(EntryPayment.Text))
            //{
                
            //}
            //else
            //{
                
            //}
        }

        private async void ButtonApply_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Search());
        }
    }
}