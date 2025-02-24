
namespace ASPCoreMVCHallBudjetProblem.Models
{
    public class HallDAO : IHall
    {
        private readonly HallDbContext dbCtx;
        public HallDAO(HallDbContext dbCtx)
        {
          this.dbCtx = dbCtx;
        }

        public List<Hall> GetHall(int price)
        {
            List<Hall> halls = new List<Hall>();
            List<Hall> hall1 = dbCtx.Hall.ToList();
            foreach (var item in hall1)
            {
                if (item.costPerDay <= price)
                {
                    halls.Add(item);
                }
            }
            return halls;
        }
    }
}
