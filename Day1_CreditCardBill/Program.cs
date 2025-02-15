namespace Day1_CreditCardBill
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the monthly payment: ");
            int amt = int.Parse(Console.ReadLine());
            double balance = 1000;
            int mont = 0;
           
            do{
                double charges = balance * 0.015;
                balance = (balance - amt)+charges ;
                mont++;
                Console.WriteLine($"Month: {mont}\t Balance : {balance}\t total Payments :{amt*mont}");

            } while (balance>0 );
        }
    }
}
