namespace EmployeeRecordArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number of Employees: ");
            int n = int.Parse(Console.ReadLine());

            Employee[] employees = new Employee[n];
            int totalSalary = 0;
            for(int i = 0; i < n; i++)
            {
                employees[i] = new Employee();
                Console.WriteLine($"\n Enter Detais for Employee{i+1}:");
                Console.WriteLine("Employee id: ");
                employees[i].EmployeeId = int.Parse(Console.ReadLine());

                Console.WriteLine("Employee Name:");
                employees[i].EmployeeName = Console.ReadLine();

                Console.WriteLine("Salary: ");
                employees[i].Salary= int.Parse(Console.ReadLine());

                Console.WriteLine("Deptid :");
                employees[i].DeptId = int.Parse(Console.ReadLine());

                totalSalary += employees[i].Salary;
            }
            Console.WriteLine("\nEmployee Details: ");
            Console.WriteLine("========================");
            foreach(var emp in employees)
            {
                emp.Display();
            }
            Console.WriteLine("Total Salary: " + totalSalary);
        }
    }
    class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Salary { get; set; }
        public int DeptId { get; set; }
        public void Display()
        {
            Console.WriteLine("Employee Id :" + EmployeeId);
            Console.WriteLine("Employee Name: "+EmployeeName);
            Console.WriteLine("Salary :"+Salary);
            Console.WriteLine("DeptId: "+DeptId);
            Console.WriteLine("-------------------------");
        }
    }
}
