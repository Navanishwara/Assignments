using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLibrary
{
    public  class Account
    {
        public int AccountId { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }


        public virtual void GetAccountDetails()
        {
            Console.WriteLine("Accont Deails");
        }
     
        

    }

    public class SavingsAccount : Account
    {
        //public decimal InterestRate { get; set; }

        public override void GetAccountDetails()
        {
            
            Console.WriteLine($"Savings Account: {AccountNumber}, Balance: {Balance}");
        }
    }
    public class CurrentAccount : Account
    {
        //public decimal OverdraftLimit { get; set; }

        public override void GetAccountDetails()
        {
            Console.WriteLine($"Current Account: {AccountNumber}, Balance: {Balance}");
        }
    }
}


