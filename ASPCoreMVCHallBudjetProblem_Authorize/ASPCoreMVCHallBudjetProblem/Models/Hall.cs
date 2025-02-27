using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPCoreMVCHallBudjetProblem.Models
{
    [Table("hall")]
    public class Hall
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("hall_name")]
        public string hallName { get; set; }
        [Column("owner_name")]
        public string OwnerName { get; set; }
        [Column("cost_per_day")]
        public int costPerDay { get; set; }
        [Column("mobile")]
        public string mobile {  get; set; }
        [Column("address")]
        public string address { get; set; }
    }
}
