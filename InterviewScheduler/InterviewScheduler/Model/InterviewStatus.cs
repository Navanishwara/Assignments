using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewScheduler.Model
{
    [Table("InterviewStatus")]
    public class InterviewStatus
    {
        [Key]
        [Column("InterviewId")]
        public int InterviewId { get; set; }
        [Column("status")]
        public string status { get; set; }
        [Column("RecomendedDesignation")]
        public string RecomendedDesignation { get; set; }
        [Column("Remarks")]
        public string Remarks { get; set; }
        [Column("offerLetterStatus")]
        public string offerLetterStatus { get; set; }
        [Column("CandidateId")]
        [ForeignKey("CandidateId")]
        public int Candidateid { get; set; }

        public List<Candidates> Candidates { get; set; }

    }
}
