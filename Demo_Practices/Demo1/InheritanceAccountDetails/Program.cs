namespace InheritanceAccountDetails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    class AccountDetails
    {
        string _holderName;
        long _accNumber;
        string _IFSCCode;
        long _contactNo;
        public AccountDetails(string hod,long acc,string ifsc, long cont)
        {
            this._holderName = hod;
            this._accNumber = acc;
            this._IFSCCode = ifsc;
            this._contactNo = cont;
        }

        public void Display()
        {
            Console.WriteLine("Hodername"+_holderName+"AccountNumbmer"+_accNumber+"_IFSCCode"+
        }

    }
}
