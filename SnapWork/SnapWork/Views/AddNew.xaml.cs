using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Plugin.FilePicker;
using GetData;
using SnapWork.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace SnapWork.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNew : ContentPage
	{
		public AddNew ()
		{
            InitializeComponent();
            ButtonChange.IsEnabled = false;
            ButtonChange.IsVisible = false;
            ButtonChange.HeightRequest = 0;

            Support.FillDropDown(PickerCity, Support.cities);

            Support.FillDropDown(PickerTypeOfWork, Support.jobList);
        }

        public AddNew(string imagePath, string title, string typeoOfWork, string payment, string city, int amountOfWorkers, string description)
        {
            InitializeComponent();

            Support.FillDropDown(PickerCity, Support.cities);
            Support.FillDropDown(PickerTypeOfWork, Support.jobList);


            ButtonApply.IsEnabled = false;
            ButtonApply.IsVisible = false;
            ButtonApply.HeightRequest = 0;
            SelectedPhoto.IsVisible = true;
            SelectedPhoto.Source = imagePath;
            EntryName.Text = title;
            PickerTypeOfWork.SelectedItem = typeoOfWork;
            EntryPayment.Text = payment;
            PickerCity.SelectedItem = city;
            EntryAmountOfWorkers.Text = amountOfWorkers.ToString();
            EditorDescription.Text = description;
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
            EntryAmountOfWorkers.TextColor = onlyDigitsValid.IsMatch(EntryAmountOfWorkers.Text) ? Color.Red : Color.Black;
        }

        private void EntryPayment_TextChanged(object sender, TextChangedEventArgs e)
        {
            EntryPayment.TextColor = onlyDigitsValid.IsMatch(EntryPayment.Text) ? Color.Red : Color.Black;
        }

        private async void ButtonApply_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Search());
        }

        [Obsolete("Метод не содержит кода, не обновляет вакансию")]
        private void ButtonChange_Clicked(object sender, EventArgs e)
        {

        }

        private async void ImagePicker_Clicked(object sender, EventArgs e)
        {
            var file = await CrossFilePicker.Current.PickFile();

            if (file != null)
            {
                SelectedPhoto.Source = file.FilePath;
                SelectedPhoto.IsVisible = true;
            }
        }
    }
}