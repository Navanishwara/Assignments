namespace Day5_DisplayEventDetails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of events");
            int n = int.Parse(Console.ReadLine());

            List<Event> eventList = new List<Event>();
            Console.WriteLine("Enter event details in CSV (eventName, organizer Name, event Cost");
            for (int i = 0; i < n; i++)
            {
                string[] details = Console.ReadLine().Split(',');
                string eventName = details[0];
                string organiserName = details[1];
                double eventCost = double.Parse(details[2]);

                Event newEvent = new Event(eventName, organiserName, eventCost);
                eventList.Add(newEvent);
            }
            Event.Display(eventList);
        }
    }
    public class Event
    {
        public string _eventName { get; set; }
        public string _organizerName { get; set; }
        public double _eventCost { get; set; }

        public Event(string eventName,string organizerName,double eventCost)
        {
            _eventName = eventName;
            _organizerName = organizerName;
            _eventCost = eventCost;
        }
        public override string ToString()
        {
            return $"Event Name: {_eventName}\t organizer Name: {_organizerName}\t eventCost{_eventCost}";
        }
        public static void Display(List<Event> eventList)
        {
            Console.WriteLine("List of event");
            eventList.ForEach(evenItem => Console.WriteLine(evenItem.ToString()));

        }
    }
}
