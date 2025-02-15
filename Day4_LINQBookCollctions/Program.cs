
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LINQBookCollctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var linBooks = BookCollections.GetBooks();
            Console.WriteLine("Enter the bookcode");
            String s1 = Console.ReadLine();
            var result = from b in linBooks
                         where b.BookCode == s1
                         select b;
            foreach (var c in result)
            {
                Console.WriteLine($"{c.BookCode}\n{c.BookName}\n{c.PublisherName}\n{c.AuthorName}\n{c.Price}");
            }
            Console.WriteLine("Enter the price ranges");
            int p = int.Parse(Console.ReadLine());
            int p1 = int.Parse(Console.ReadLine());
            var range = from bb in linBooks
                        where bb.Price > p && bb.Price < p1
                        select bb;
            foreach (var item in range)
            {
                Console.WriteLine($"prices {item.Price}\n");
            }

        }
        class BookCollections
        {
            public string BookCode { get; set; }
            public string BookName { get; set; }
            public string PublisherName { get; set; }
            public string AuthorName { get; set; }
            public double Price { get; set; }

            public static List<BookCollections> GetBooks()
            {
                return new List<BookCollections>
            {
                new BookCollections {BookCode ="ASPNA",BookName = "ASP.Net Professional",PublisherName = "Wrox",AuthorName="Bil Evjen, Matt Gibbs",Price=750.00 },
                 new BookCollections { BookCode = "ASPNB", BookName = "Begining ASP .Net", PublisherName = "TechMedia", AuthorName = "Dan Wahlin", Price = 545.00 },
                  new BookCollections { BookCode = "LNQA", BookName = "Learning LINQ", PublisherName = "APress", AuthorName = "Steve Eichert", Price = 400.00 },
                   new BookCollections { BookCode = "CSPN", BookName = "C# Developers Guide", PublisherName = "Tata McGraw", AuthorName = "Dan Maharry", Price = 675.00 }

            };

            }
        }

    }
}
