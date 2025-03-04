namespace ConsturctorDeconstruct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Employee emp = new Employee(101, "rama", 230000);

            Console.WriteLine(emp.ToString());
            Employee emp1 = new Employee(102, "krisha", 400000);
        }
    }
    class Employee
    {
        int ecod;
        string ename;
        int salary;
       static string companyName;
        public Employee(int ecod, string ename, int salary)
        {
            this.ecod = ecod;
            this.ename = ename;
            this.salary = salary;
          
            Console.WriteLine("consturctor is called");
        }
        static Employee()
        {
            Employee.companyName = "Tavant";//
        }
        public override string ToString()
        {
            return $"{ecod}\t{ename}\t{salary}\t{companyName}";
        }
    }
}
