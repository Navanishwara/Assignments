namespace DiscountForCustomerInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Privileage Customer");
            Console.WriteLine("2. Senior-Citizen Customer");
            Console.WriteLine("Enter Customer Type");
            int op = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the name");
            String name = Console.ReadLine();
            Console.WriteLine("Enter  the age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the a address");
            String add = Console.ReadLine();
            Console.WriteLine("Enter the mobile No");
            String mob = Console.ReadLine();
            Console.WriteLine("Enter the amount");
            int amt = int.Parse(Console.ReadLine());

            Customer customer = new Customer();
            customer.name = name;
            customer.age = age;
            customer.address = add;
            customer.mobileNo = mob;
            customer.amount = amt;
            customer.DisplayCustomer();

            if (op == 1)
            {
                Customer customer1 = new PrivilageCustomer();
                Console.WriteLine("Your Bill Amount is RS "+customer.amount);
                Console.WriteLine("Your bill amount is discount under privilege customer You have to pay RS " + customer1.GenerateBillAmount(amt));

            }
            else if (op == 2)
            {
                Customer customer2 = new SeniorCitizonCustomer();
                Console.WriteLine("Your Bill Amount is RS " + customer.amount);
                Console.WriteLine("Your bill amount is discount under senior citizen customer You have to pay" + customer2.GenerateBillAmount(amt));


            }
            else
            {
                Console.WriteLine("Invalid Cutomer Type");
            }
        }
    }

    class Customer
    {
        public string name { get; set; }
        public int age { get; set; }
        public string address { get; set; }

        public string mobileNo { get; set; }

        public int amount { get; set; }
        public void DisplayCustomer()
        {
            Console.WriteLine("Name: " + name + "Address: " + address + "MobileNo:" + mobileNo + "age: " + age);
        }
        public virtual double GenerateBillAmount(int amount)
        {
            return amount;
        }
    }
    class SeniorCitizonCustomer : Customer
    {
        public override double GenerateBillAmount(int amt)
        {
            double total = amt - (amt * 0.12);
            return total;
        }
    }
    class PrivilageCustomer : Customer
    {
        public override double GenerateBillAmount(int amt)
        {
            double total = amt - (amt * 0.3);
            return total;
        }
    }


}
