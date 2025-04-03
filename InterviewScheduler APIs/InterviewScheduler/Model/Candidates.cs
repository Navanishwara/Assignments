using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewScheduler.Model
{
    [Table("Candidates")]
    public class Candidates
    {
        [Key]
        [Column("CandidateId")]
        public int CandidateId { get; set; }
        [Column("CandidateName")]
        public string CandidateName { get; set; }
        [Column("emailId")]
        public string emailId { get; set; }
        [Column("resume")]
        public byte[] resume { get; set; }

    }
}
