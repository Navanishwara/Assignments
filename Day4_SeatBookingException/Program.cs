namespace Day4_SeatBookingException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the booking Detils");
            string detail = Console.ReadLine();
            Console.WriteLine("Enter the seat number to book");
            int seatNo = int.Parse(Console.ReadLine());
            char[] seat = detail.ToCharArray();
            try
            {
                if (seatNo < 1 || seatNo > seat.Length)
                {
                    throw new IndexOutOfRangeException("Array index out of range");
                }
                if (seat[seatNo - 1] == '0')
                {
                    seat[seatNo - 1] = '1';
                    Console.WriteLine("booked successfully");
                }
                else
                {
                    throw new SeatNotAvailableException("seat booked already");
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SeatNotAvailableException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public class SeatNotAvailableException : Exception
    {
        public SeatNotAvailableException(string err) : base(err)
        {

        }
    }
}
