namespace Constructor_chaining
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Manager m1 = new Manager(101, "John", 40000);
            Console.WriteLine(m1.ToString());

        }
    }
    class Employee
    {
        int ecode;
        string ename;
        public Employee(int ecode, string ename)
        {
            this.ecode = ecode;
            this.ename = ename;
        }
        public override string ToString()
        {
            return $"{ecode}\t{ename}";
        }
    }
    class Manager: Employee
    {
        int bonus;
        public Manager( int ecode,string enamem,int bonus): base(ecode,ename)
        {
            this.bonus = bonus;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
