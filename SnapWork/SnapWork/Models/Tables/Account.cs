using System;

namespace SnapWork.Models
{
    public class Account
    {
        // До
        public int IdAccount { get; set;}
        public string NickName { get; set;}
        [Obsolete]
        public string Photo { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public decimal AmountOfMoney { get; set; }
        public string Location { get; set; }
        public decimal Rate { get; set; }
        public DateTime TimeOnSite { get; set; }
        public string Resume { get; set; }
    }
}
