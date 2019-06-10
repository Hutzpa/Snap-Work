using GetData;
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
	public partial class Feedback : ContentPage
	{

        public List<WorkrList> Workers { get; set; }

		public Feedback ()
		{
			InitializeComponent ();
            Workers.Add(new WorkrList
            {
                Id = 1,
                IdAccount = new Account
                {
                    Photo = "bla.jpg",
                    NickName = "lox228"
                },
                vacancy = null
            });

            marks = new int[Workers.Count];
		}

        private int[] marks;


        private void Rate1_Clicked(object sender, EventArgs e)
        {
            Button Rate1 = (Button)sender;
            Rate1.ImageSource = "FullStar.png";
            //marks[e.]
        }

        private void Rate2_Clicked(object sender, EventArgs e)
        {

            Button Rate2 = (Button)sender;
            Rate2.ImageSource = "FullStar.png";
        }

        private void Rate3_Clicked(object sender, EventArgs e)
        {
            Button Rate3 = (Button)sender;
            Rate3.ImageSource = "FullStar.png";
        }

        private void Rate4_Clicked(object sender, EventArgs e)
        {
            Button Rate4 = (Button)sender;
            Rate4.ImageSource = "FullStar.png";
        }

        private void Rate5_Clicked(object sender, EventArgs e)
        {
            Button Rate5 = (Button)sender;
            Rate5.ImageSource = "FullStar.png";
        }
    }

    public class WorkrList
    {

        public int Id { get; set; }
        public Vacancy vacancy { get; set; }
        public Account IdAccount { get; set; }
    }
}