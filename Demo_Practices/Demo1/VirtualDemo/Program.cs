namespace VirtualDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            int marks = 55;
            College1 college1 = new College1();
            Console.WriteLine("College Result1: "+college1.GetResult(marks));

            //int mark = 49;
            College2 college2 = new College2();
            Console.WriteLine("College Result2: " + college2.GetResult(marks));

        }
    }
    class Univercity
    {
        public  virtual string GetResult(int marks)
        {
            if(marks >= 50)
            {
                return "pass";
            }
            else
            {
                return "Fail";
            }
        }
    }
    class College1 : Univercity
    {
    }
    class College2 : Univercity
    {
        public override string GetResult(int marks)
        {
            return base.GetResult(marks);
        }
    }
}
