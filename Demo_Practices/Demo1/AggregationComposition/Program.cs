namespace AggregationComposition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Computer computer = new Computer();

            //Mouse mouse = new Mouse();  
            //Monitor monior = new Monitor(); 
            
            //computer.setData(mouse, monior);//aggregation
            computer.SetData();//Composition
            computer.display();
            computer = null;


        }
    }
    class Mouse
    {
        public void MouseFeature()
        {
            Console.WriteLine("Mouse");
        }
    }
    class Moniter
    {
        public void MoniterFeature()
        {
            Console.WriteLine("Moniter");
        }
    }
    class Computer
    {
        Mouse mouse;
        Moniter moniter;
        public void SetData(Mouse mouse, Moniter moniter)
        {
            //this.mouse = mouse;//agregation
            //this.moniter = moniter;

            mouse = new Mouse();
            moniter = new Moniter();//Composition
        }
        public void display()
        {
            this.moniter.MoniterFeature();
            this.mouse.MouseFeature();
        }
    }
}
