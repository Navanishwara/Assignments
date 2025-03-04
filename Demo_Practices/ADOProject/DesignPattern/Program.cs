namespace DesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employee employee = new Employee
            //{
            //   Id = 101,
            //   Name = "ravi",
            //    Salary = 7000
            //};
            //employee.Display();
            Console.WriteLine("Area of shapes");
            Console.WriteLine("1.Square");
            int choice = int.Parse(Console.ReadLine());
            AreaCalculator calculator = new AreaCalculator(); 
            double area = calculator.CalculateArea(choice);
            Console.WriteLine($"Arae of {(choice == 1 ? "square":"circle")}");

        }
    }
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public void Display()
        {
            Console.WriteLine($"id\t{Id}\t{ Name}");
        }
        double getBonus()
        {
            double bonus = 0;
            if (Salary > 0)
            {
                bonus = 0.1 * Salary;
            }
            else
            {
                bonus = 0.2 * Salary;
            }
            return bonus;   
        }
    }
}
