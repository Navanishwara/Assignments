namespace Day1_compundIntrest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            double amt = 1000;
            int year = 0;

            do
            {
                Console.WriteLine($"Year :{year}\t {amt}");
                amt = amt + (amt * 0.05);
                
                year++;

            } while (amt <= 1000000);
            Console.WriteLine("Total No of Years  "+(year-1));

        }
    }
}
