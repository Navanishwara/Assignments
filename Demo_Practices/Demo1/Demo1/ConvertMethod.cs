using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1
{
    internal class ConvertMethod

    {
        public void Demo() 
        {
            //Working with System.Convert method
            double d1 = Convert.ToDouble("12.5");
            Console.WriteLine(d1);

            //Parse method
            //it is used always  form string type to other type
            string s1 = "10.5";
            //double d2 = double.Parse(s1);
            //double d2 = Convert.ToDouble(s1);
            double d2 = 0;
            double.TryParse(s1, out d2);

            Console.WriteLine(d2);

        }
    }
}
