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

        public List<Fedb> Workers { get; set; }

		public Feedback (int OwnerId, int VacantionId)
		{
			InitializeComponent ();
            Workers = FillWorkers();

		}

        private List<Fedb> FillWorkers()
        {
            return new List<Fedb>();
        }

        private void Rate1_Clicked(object sender, EventArgs e)
        {
            //в зависимости от нажатой кнопки, отправлять 1,2,3... 

            Button Rate1 = (Button)sender;
            Rate1.ImageSource = "FullStar.png";
            
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

    public class Fedb
    {
        public int IdAccount { get; set; }
        public string NickName { get; set; }
        public double Rate { get; set; }

        public int ListOfWId { get; set; }
        public int IdVacancy { get; set; }
    }
    
}