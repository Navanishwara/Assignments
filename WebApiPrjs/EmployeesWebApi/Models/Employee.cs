using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesWebApi.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        [Column("empid")]
        public int Empid { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("salary")]
        public int Salary { get; set; }
        [Column("depid")]
        public int Deptid { get; set; }

    }
}
