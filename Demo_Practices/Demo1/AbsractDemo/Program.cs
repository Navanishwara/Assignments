namespace AbsractDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //static binding
            Console.WriteLine("static binding");
           Circle c = new Circle();
            c.Area();
            Square square = new Square();
            square.Area();
            //dynamic binding --declaration should be base type.
            Console.WriteLine("dynamic binding");
            Shape sh;
            sh = new Circle();
            sh.Area();

            sh = new Square();
            sh.Area();
        }
    }
    abstract class Shape
    {
        public abstract void Area();
    }
    class Circle : Shape
    {
        public override void Area()
        {
            Console.WriteLine("Area of Circle");
        }
    }
    class Square : Shape
    {
        public override void Area()
        {
            Console.WriteLine("Area of shape");
        }
    }
}
