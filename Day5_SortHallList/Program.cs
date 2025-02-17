using System;
using System.Collections.Generic;
namespace Day5_SortHallList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of halls:");
            int n = int.Parse(Console.ReadLine());
            List<Hall> hallList = new List<Hall>();
            Console.WriteLine("Enter the hall details ");
            Console.WriteLine("Enter Name,costPer day,OwnerName");
            for (int i = 0; i < n; i++)
            {
                string[] details = Console.ReadLine().Split(',');
                string name = details[0];
                double costToPer = double.Parse(details[1]);
                string owner = details[2];

                Hall hall = new Hall(name, costToPer, owner);
                hallList.Add(hall);
                
            }

            hallList.Sort((h1,h2) => h1._owner.CompareTo(h2._owner));
            Console.WriteLine("Hall list");
            Console.WriteLine("{0,-15}{1,-10}{2,-10}", "Name", "Cost", "Owner");
            foreach (Hall hall in hallList)
            {
                Console.WriteLine(hall);
            }
        }
    }
    public class Hall : IComparable<Hall>
    {
        public string _name { get; set; }
        public double _costPerday { get; set; }
        public string _owner { get; set; }
        public Hall(string name, double costPerday, string owner)
        {
            _name = name;
            _costPerday = costPerday;
            _owner = owner;
        }
        public override string ToString()
        {
            return $" {_name}\t {_costPerday}\t  {_owner}";
        }
        public int CompareTo(Hall other)
        {
            return this._name.CompareTo(other._name);
        }
    }

}
