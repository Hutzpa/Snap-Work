﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetData;
using SnapWork.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnapWork.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPeople : ContentPage
    {
        public List<Account> People { get; set; }

        public SearchPeople()
        {
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);

            People = FillPeople();

            Support.FillDropDown(JobPick, Support.jobList);
            Support.FillDropDown(PickCity, Support.cities);

            this.BindingContext = this;
        }


        private List<Account> FillPeople()
        {
            //нужно получать последнии специальности каждого рабочего
            List<Account> vacancies = new List<Account>();
            for (int i = 0; i < 10; i++)
            {
                vacancies.Add(new Account
                {
                    NickName = "Ivan" + i,
                    Photo = "bla.jpg",
                    Location = "Kharkov" + i,
                    AmountOfMoney = i

                });
            }

            return vacancies;
        }

        private void WorkersList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync((Page)Activator.CreateInstance(typeof(Facepage),e.Item as Account));
        }
    }
}