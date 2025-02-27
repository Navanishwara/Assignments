using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPCoreMVC.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        [Column("empid")]
        [Required]
        [RegularExpression(@"\d{3,3}",ErrorMessage ="Ecode must be 3 digits")]
        public int empid { get; set; }
        [Column("name")]
        [Required]
        [StringLength(10)]
        public string name { get; set; }
        [Column("salary")]
        [Required]
        [Range(500,20000)]

        public int salary { get; set; }
        [Column("depid")]
        [Required]
        public int deptid { get; set; }
        public static List<Employee> employees = new List<Employee>
        {
            new Employee { empid =101,name ="rames",salary=20000,deptid=201 },
             new Employee { empid =101,name ="rakesh",salary=20000,deptid=203 },
              new Employee { empid =101,name ="suresh",salary=20000,deptid=205 },
               new Employee { empid =101,name ="ram",salary=20000,deptid=205 }
        };
    }
}

