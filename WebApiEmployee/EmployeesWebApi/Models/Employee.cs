using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

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

        //public static explicit operator OkObjectResult(Employee v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
