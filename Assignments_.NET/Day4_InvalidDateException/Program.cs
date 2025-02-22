namespace InvalidDateException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the start date(dd/mm/yyyy hh:mm:ss tt):");
                string s1 = Console.ReadLine();
                DateTime dt = DateTime.ParseExact(s1, "dd/MM/yyyy hh:mm:ss tt", null);
               

                Console.WriteLine("Enter the End date(dd/mm/yyyy hh:mm:ss tt):");
                string s2 = Console.ReadLine();
                DateTime dd = DateTime.ParseExact(s2, "dd/MM/yyyy hh:mm:ss tt", null);

                Console.WriteLine("start date :" + dt.ToString("dd/MM/yyyy hh:mm:ss tt"));
                Console.WriteLine("End date :" + dd.ToString("dd/MM/yyyy hh:mm:ss tt"));

            }catch (Exception )
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
