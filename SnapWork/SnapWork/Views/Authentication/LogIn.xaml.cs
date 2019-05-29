﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnapWork.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogIn : ContentPage
	{
		public LogIn ()
		{
			InitializeComponent ();

            TapGestureRecognizer tapGestureReg = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 2
            };

            int countReg = 0;  // счетчик нажатий
            tapGestureReg.Tapped += (s, e) =>
            {
                countReg++;
                if (countReg % 2 == 0)
                {
                    Navigation.PushAsync(new Register());
                }
                
            };
            LabelRegister.GestureRecognizers.Add(tapGestureReg);

            TapGestureRecognizer tapGestureRestor = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 2
            };

            int countRest = 0;  // счетчик нажатий
            tapGestureRestor.Tapped += (s, e) =>
            {
                countReg++;
                if (countRest % 2 == 0)
                {
                    Navigation.PushAsync(new RestorePassword());
                }

            };
            LabelRestore.GestureRecognizers.Add(tapGestureRestor);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (CheckLogin())
            {
             Application.Current.MainPage = new MainPage();

            }
            else
            {
                LabelInvalid.IsVisible = true;
            }

        }

        [Obsolete("Логика проверки логина и пароля не написана")]
        private bool CheckLogin()
        {
            return true;
            /// логика 
        }

    }
}