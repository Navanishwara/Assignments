namespace Day3_FeedbackArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of Customers");
            int n = int.Parse(Console.ReadLine());
            Customer[] feed = new Customer[n];
            for (int i = 0; i < n; i++)
            {
                feed[i] = new Customer();
                Console.WriteLine($"Enter the details of  Employee {i + 1}:");
                Console.WriteLine("Enter the Name");
                feed[i].Name = Console.ReadLine();
                Console.WriteLine("Enter the MobileNumber");
                feed[i].MobileNumber = Console.ReadLine();
                Console.WriteLine("Enter the FeedbackRating");
                feed[i].FeedbackRating = double.Parse(Console.ReadLine());

            }
            Console.WriteLine("Employee details");
            double sum = 0;

            foreach (var cu in feed)
            {
                sum += cu.FeedbackRating;
                Console.WriteLine($"Name :{cu.Name}\nMobileNo: {cu.MobileNumber} FeedbackRating: {cu.FeedbackRating}");
            }
            double avg = sum / n;
            Console.WriteLine("Average Feedback: "+avg);

        }
        
        class Customer
        {
            public string Name { get; set; }
            public string MobileNumber { get; set; }
            public double FeedbackRating { get; set; }


        }
    }
}
