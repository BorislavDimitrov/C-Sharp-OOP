using System;
using System.Collections.Generic;
using System.Text;

namespace Stealer
{
    public class Hacker
    {
        public string username = "securitygod82";
        private string password = "mySuperSecretPassw0rd";

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private int Id { get; set; }

        public double BankAccountBalance { get; private set; }

        public void DownloadAllBankAccountsInTheWorld()
        {

        }
    }
}
