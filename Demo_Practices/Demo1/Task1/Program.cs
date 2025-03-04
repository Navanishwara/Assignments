namespace Task1

{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[,] seats = new int[25,25];
            while (true)
            {
                Console.WriteLine("Enter the No of Seats");
                int no = int.Parse(Console.ReadLine());
                
                int seatNos = no;
                Console.WriteLine("enter the seat nos");
                int seatno = int.Parse(Console.ReadLine());

                int row = seatno / 25;
                int col = (seatno % 25)+1;
                if (no == 0)
                {
                    Console.WriteLine("give valid no of seates");
                }
                else {
                    for (int k = 0; k < seatNos; k++)
                    {
                        for (int i = 1; i <= seats.GetLength(0); i++)
                        {
                            for (int j = 1; j <= seats.GetLength(1); j++)
                            {
                                seats[row, col+k] = 1;
                            }
                        }
                        
                    }

                }
                    for (int i = 0; i < seats.GetLength(0); i++)
                    {
                        for (int j = 0; j < seats.GetLength(1); j++)
                        {
                            Console.Write(seats[i, j] + " ");
                        }
                        Console.WriteLine();
                    }



                }
            
        }

        
    }
}

