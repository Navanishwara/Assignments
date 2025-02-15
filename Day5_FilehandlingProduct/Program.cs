using System.IO;
namespace FilehandlingProduct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadText();
        }
        static void ReadText()
        {
            FileStream fl = null;
            FileStream fl2 = null;  
            try
            {
                fl = new FileStream("product.txt", FileMode.Open, FileAccess.Read);
                fl2 = new FileStream("product_updated.txt", FileMode.Create, FileAccess.Write);


                StreamReader sl = new StreamReader(fl);
                StreamWriter sl2 = new StreamWriter(fl2);

                string str = sl.ReadLine();
                
               
                while (!String.IsNullOrEmpty(str))
                {
                    string[] col = str.Split(",");
                    double price = double.Parse(col[2]);
                    Console.WriteLine(price);
                    if (price < 1000)
                    {
                        price = price + (price * 0.1);
                    }
                    else if (price > 1000 && price < 5000)
                    {
                        price += (price * 0.05);
                    }
                    else
                    {

                    }
                    col[2] = " " + price;
                    string str2 = string.Join(",", col);
                    sl2 .WriteLine(str2);

                    
                    str = sl.ReadLine();
                    //str2 = str;
                }
                sl.Close();
                sl2.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fl.Close();
                fl.Close();
            }
        }

    }
}
