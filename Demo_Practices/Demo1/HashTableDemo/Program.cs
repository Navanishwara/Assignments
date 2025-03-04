using System.Collections;
namespace HashTableDemo

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Hashtable ht = new Hashtable();
            ht.Add(101, "Ravi");
            ht.Add(102, "rama");

        Console.WriteLine(ht[101].ToString());
            foreach (object k in ht.Keys) {
                Console.WriteLine(ht[k]);
            }
        }
    }
}
