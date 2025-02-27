using System.ComponentModel.DataAnnotations.Schema;

namespace ASPCoreMVC.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Cname { get; set; }

        [ForeignKey("CourseId")]
        public Course CourseId { get; set; }
    }
}
