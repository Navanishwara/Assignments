using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    internal class AreaCalculator
    {
       public double CalculateArea(IShape shape) 
        {
            double area = 0;
            area = shape.CalculateArea();
            //switch (choice)
            //{
            //    case 1:
            //        //area of square
            //        Square square = new Square{ Length =100, Breadth =100};
            //        area = square.Length * square.Breadth;
            //        Console.WriteLine($"Area of Square :{area}");
            //        break;
            //    case 2:
            //        //area of circle
            //        Circle circle = new Circle {
            //            Radius = 10
            //        };
            //        area = 3.14*circle.Radius*circle.Radius;
            //        Console.WriteLine($"Area of circle{area}");
            //        break;
            //}
            return area;    
        }
    }
}
