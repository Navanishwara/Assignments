using System.Collections;
namespace ProductCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <Product> prod = new List<Product>();
            prod.Add(new Product(200, "Dell", "15 inch Monitor", 3400.44));
            prod.Add(new Product(120, "Dell", "Laptop", 45000.00));
            prod.Add(new Product(150, "Microsoft", "Windows 7", 7000.50));
            prod.Add(new Product(100, "Logitech", "Optical Mouse", 540.00));

            Console.WriteLine("1.Default\n 2.NameSort\n3.PriceSort");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        prod.Sort();
                        break;
                    }
                case 2:
                    {
                        prod.Sort(new NameSort());
                        break;
                    }
                case 3:
                    {
                        prod.Sort(new PriceSort());
                        break;
                    }
                default:
                    {
                        Console.WriteLine("invalid input");
                        break;
                    }
            }
            
           foreach(Product p in prod)
            {
                Console.WriteLine(p.ToString());

            }
        }
    }
    class Product : IComparable<Product>
    {
       public int _productID { get; set; }
        public string _brandName { get; set; }
       public string _description { get; set; }
        public double _price { get; set; }
        public Product(int productID, string brandName, string description, double price)
        {
            _productID = productID;
            _brandName = brandName;
            _description = description;
            _price = price;

        }

        public int CompareTo(Product? other)
        {
            if (this._productID > other._productID)
            {
                return 1;

            }
            else if (this._productID < other._productID)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        //public void Display()
        //{
        //    Console.WriteLine($"Product: {_productID} BrandName: {_brandName} description {_description} price : {_price}");
        //}
        public override string ToString()
        {
            return $"Product: {_productID} BrandName: {_brandName} description {_description} price : {_price}";
        }
    }
        class NameSort : IComparer<Product> {
            public int Compare(Product? x, Product? y)
            {
                if (x._brandName.CompareTo(y._brandName) == 0)
                {
                    return x._description.CompareTo(y._description);
                }
                else
                {
                    return x._brandName.CompareTo(y._brandName);

                }
            }

            
        }
    

        class PriceSort: IComparer<Product>
        {
            public  int Compare(Product ?x, Product ? y)
            {
                if(x._price > y._price)
                {
                    return 1;
                }else if( x._price < y._price)
                {
                    return -1;
                }
                else
                {
                   if(x._productID>y._productID) {
                        return 1;
                    }else if (x._productID < y._productID)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        
    

}
