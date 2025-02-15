using System.Runtime.CompilerServices;

namespace GST_Calculation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter event Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the cost per day");
            double costPerDay = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Number of days");
            int noOfDays = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the type of event\n1.Exhibition\n2.Staged Event");
            int eventType = Convert.ToInt32(Console.ReadLine());

            if (eventType == 1)
            {
                Console.WriteLine("Enter the number of stalls");
                int noOfstalls = Convert.ToInt32(Console.ReadLine());
                Exhibition exhibition = new Exhibition(name, "Exhibition", costPerDay, noOfDays, noOfstalls);
                Console.WriteLine("Event Details");
                Console.WriteLine(exhibition);
            }
            else if (eventType == 2)
            {
                Console.WriteLine("Enter the number of seats");
                int noOfSeats = Convert.ToInt32(Console.ReadLine());
                StageEvent stageEvent = new StageEvent(name,"Stage Event",costPerDay, noOfDays,noOfSeats);
                Console.WriteLine("Event Details");
                Console.WriteLine(stageEvent);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
    public class Event
    {
        protected string _name;
        protected string _type;
        protected double _costPerDay;
        protected int _noOfDays;

        public Event() { }
        public Event(String name, string type, double costPerDay, int noOfDays)
        {
            _name = name;   
            _type = type;
            _costPerDay = costPerDay;   
            _noOfDays = noOfDays;

        }
    }
    public class Exhibition : Event
    {
        private static int _gst = 5;
        private int _noOfStalls;

        public Exhibition(string name, string type, double costPerDay, int noOfDays, int noOfStalls) :
            base(name, type, costPerDay, noOfDays)
        {
            _noOfStalls = noOfDays;
        }
        public double TotalCost()
        {
            double cost = _costPerDay * _noOfStalls;
            return cost + (cost * _gst / 100);
        }
        public override string ToString()
        {
            return $"Name:{_name}\nType:{_type}\n Number of stalls :{_noOfStalls}\n Total_amount:{TotalCost():0.00}";
        }
    }

    public class StageEvent: Event
    {
        private static int _gst = 15;
        private int _noOfSeats;
        public StageEvent(string name, string type, double costPerDay, int noOfDays, int noOfSeats)
            : base(name,type,costPerDay,noOfDays)
        {
            _noOfSeats = noOfSeats;

        }
        public double TotalCost()
        {
            double cost = _costPerDay * _noOfSeats;
            return cost + (cost * _gst / 100);

        }
        public override string ToString()
        {
            return $"Name: {_name}\n Type: {_type}\n Number of seats: {_noOfDays} \n Total amount:{TotalCost():0.00}";
        }
    }


}
