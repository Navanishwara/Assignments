using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    internal class Square : IShape
    {
        public int Length { get; set; }
        public int Breadth { get; set; }

        public double CalculateArea()
        {
            return this.Length * this.Breadth;
        }
    }
}
