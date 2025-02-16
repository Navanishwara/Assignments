using System;
using System.Collections.Generic;
using System.Linq;

namespace Day5_placemantDirectorGroupby
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the no of companies");
            int n = int.Parse(Console.ReadLine());
            List<PlaceStudent> place = new List<PlaceStudent>();
            for (int i = 0; i < n; i++) {
                Console.WriteLine("Enter company Name");
                string companyName = Console.ReadLine();
                Console.WriteLine("Enter student Name");
                string studentName = Console.ReadLine();

                place.Add(new PlaceStudent(companyName, studentName));
            }

            var grStu = place
                .OrderBy(s => s._studentName)
                .GroupBy(s => s._companyName)
                .OrderBy(g => g.Key);
            foreach (var gr in grStu) {
                Console.WriteLine($"Company Name: {gr.Key}");
                foreach (var student in gr) {
                    Console.WriteLine(student._studentName);
            }

            }
        }
        public class PlaceStudent
        {
            public string _companyName { get; set; }

            public string _studentName { get; set; }

            public PlaceStudent(string companyName, string studentName)
            {
                _companyName = companyName;
                _studentName = studentName;
            }
        }
    }
}
