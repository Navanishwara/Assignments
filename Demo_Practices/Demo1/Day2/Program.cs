public class Program
{
    static void Main(string[] args)
    {
        DateTime date = DateTime.Now;
        Console.WriteLine(date);
        string s1 = "23-05-2025";
        DateTime date2 = DateTime.ParseExact(s1, "dd-mm-yyyy", null);
        Console.WriteLine(date2);
        Console.WriteLine(date2.ToString("dd-MMM-yyyy"));

        DateTime dt3 = date2.AddDays(1);
        Console.WriteLine(dt3);
        //----------------------------------------------------------------

        int salary = 7000;
        double bonus = 0;
        Console.WriteLine($"Before: salary:{salary}\t bonus: {bonus}");

        CaclulateBonus(salary, bonus);
        Console.WriteLine($"After: salary:{salary}\t bonus: {bonus}");

        static void CaclulateBonus(int sal , double bon)
        {
            bon = sal * 0.1;
        }
    }
}

