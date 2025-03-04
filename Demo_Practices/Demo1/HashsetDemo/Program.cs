using System.Collections;
namespace HashsetDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            HashSet<string> set1 = new HashSet<string>();
            set1.Add("ramesg");
            set1.Add("ramesh");
            HashSet<string> set2 = new HashSet<string>();
            set1.Add("raivi");
            set1.Add("rakesh");
            //no duplicates values and support set operation union intersect , minus;
            set1.UnionWith(set2);
            //set1.IntersectWith(set2);
            //set1.ExceptWith(set2);
            foreach (string s in set1)
            {
                Console.WriteLine(s);
            }
        }
    }
}
