using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace AccountDetails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter  user details(holderName, Account Number, IFSC code, contact Number)");
            string[] userdetails = Console.ReadLine().Split(',');
            if (userdetails.Length != 4)
            {
                Console.WriteLine("Invalid input format.");
                return;
            }
            string holderName = userdetails[0];
            long accountNumber = long.Parse(userdetails[1]);
            string IFSCCOde = userdetails[2];
            long contactNumber = long.Parse(userdetails[3]);

            Console.WriteLine("Enter Account Type");
            string accountType = Console.ReadLine().ToLower();
            if (accountType == "saving")
            {
                Console.WriteLine("enter intrest rate");
                double intretRate = double.Parse(Console.ReadLine());
                SavingAccount savingaccount = new SavingAccount(holderName, accountNumber, IFSCCOde, contactNumber, intretRate);
                savingaccount.Display();

            }
            else if (accountType == "current")
            {
                Console.WriteLine("Enter organizain Name");
                string organizationName = Console.ReadLine();
                Console.WriteLine("Enter TIN number");
                long TIN = long.Parse(Console.ReadLine());

                CurrentAccount currentAccount = new CurrentAccount(holderName, accountNumber, IFSCCOde, contactNumber, organizationName, TIN);
                currentAccount.Display();
            }
            else
            {
                Console.WriteLine("Enter valid account Type");
            }
        }
        class Account
        {
            private string _holderName;
            private long _accountNumber;
            private string _IFSCCode;
            private long _contactNumber;

            public Account() { }
            public Account(string holderName, long accountNumber, string IFSCCode, long contactNumber)
            {
                _holderName = holderName;
                _accountNumber = accountNumber;
                _IFSCCode = IFSCCode;
                _contactNumber = contactNumber;
            }
            public void Display()
            {
                Console.WriteLine("Your contact Details");
                Console.WriteLine($"Holder Name : {_holderName} \n Account Number: {_accountNumber} \n IFSCCode{_IFSCCode}\n contactNo:{_contactNumber}\n");
            }
        }

        class SavingAccount : Account
        {
            private double _intrestRate;
            public SavingAccount(string holderName, long accountNumber, string IFSCCode, long contactNo, double intrestRate) :
                base(holderName, accountNumber, IFSCCode, contactNo)
            {
                _intrestRate = intrestRate;

            }
            public new void Display()
            {
                base.Display();
                Console.WriteLine($"Interest Rate: {_intrestRate}");
            }

        }

        class CurrentAccount : Account
        {
            private string _organizationName;
            private long _TIN;
            public CurrentAccount(string holdername, long accountNumber, string IFSCCode, long contactNo, String organizationName, long TIN) :
                base(holdername, accountNumber, IFSCCode, contactNo)
            {
                _organizationName = organizationName;
                _TIN = TIN;
            }
            public new void Display()
            {
                base.Display();
                Console.WriteLine($"Organization Name : {_organizationName} \n TIN : {_TIN}");
            }
        }

    }
}
