namespace ASPCoreMVCRentCalculation.Models
{
    public class RentCalculation
    {
        public String Name { get; set; }
        public String HallOwner { get; set; }
        public int  Cost { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

    }
}
