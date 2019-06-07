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
	public partial class Page1 : ContentPage
	{
        public List<Accountо> People { get; set; }

        public List<Phone> Phones { get; set; }

        public Page1 ()
		{
			InitializeComponent ();
            //Phones = new List<Phone>
            //{
            //    new Phone {Title="Galaxy S831321312312312", Company="Samsun21321312g", Price=43218000 },
            //    new Phone {Title="Hua432432423wei P10", Company="Hua432423423wei", Price=35432000 },
            //    new Phone {Title="HTC U Uауцацуацуltra", Company="HTC", Price=46542000 },
            //    new Phone {Title="iPhoауцацуацуацуne 7", Company="Appауацуацle", Price=52043200 }
            //};

            People = new List<Accountо>
            {
                new Accountо{ NickName = "Ivan", Photo = "bla.jpg", AmountOfMoney = 5000 },
                new Accountо{ NickName = "Ivan44", Photo = "bla.jpg", AmountOfMoney = 800 },
                new Accountо{ NickName = "Ivan55", Photo = "bla.jpg", AmountOfMoney = 900 },
                new Accountо{ NickName = "Ivan66", Photo = "bla.jpg", AmountOfMoney = 678000}

            };
            this.BindingContext = this;
		}
	}

    public class Accountо
    {
        public string NickName { get; set; }
        public string Photo { get; set; }
        public int AmountOfMoney { get; set; }
        //public string Location;
    }

    public class Phone
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
    }
}