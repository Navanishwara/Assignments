namespace inheritancep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            TwoWheeler discover = new TwoWheeler();
            discover.Break();
        }
    }
    class vehicle
    {
        public Break()
        {
            Console.WriteLine("Break");
        }
        public Horn()
        {
            Console.WriteLine("Horn");
        }
    }
    class TwoWheeler : vehicle
    {
        
    }
    class FourWheeler : vehicle
    {

    }

}
