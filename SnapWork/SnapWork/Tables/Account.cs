using System;

namespace SnapWork
{
    public class Account
    {
        public int idAccount;
        public string nickName;
        [Obsolete]
        public string photo;
        public string password;
        public string phone;
        public string email;
        public DateTime birthDay;
        public decimal amountOfMoney;
        public string location;
        public decimal rate;
        public DateTime timeOnSite;
        public string resume;
    }
}
