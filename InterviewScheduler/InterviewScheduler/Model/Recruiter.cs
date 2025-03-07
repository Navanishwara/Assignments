using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewScheduler.Model
{
    [Table("recruiters")]
    public class Recruiter
    {
        [Key]
        [Column("recruiterId")]
        public int RecruiterId {  get; set; }
        [Column("date")]
        public DateOnly Date {  get; set; }
        [Column("time")]
        public TimeOnly Time { get; set; }
        [Column("Rounds")]
        public int Rounds { get; set; }
        [Column("name")]
        public string Name {  get; set; }
        [Column("designation")]
        public string Designation { get; set; }
        [Column("emailId")]
        public string EmailId {  get; set; }

    }
}
